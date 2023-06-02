# Running website and configuring IIS for accessibility in local network

1. Enable Windows features - check IIS services features.  
   After enabling it: - Panel sterowania -> Narzędzia administracyjne (Control Panel -> Administrative Tools) - here we should see IIS services listed - we should have C:\Windows\System32\inetsrv\inetmgr.exe file and the directory should contain installation of IIS.
2. Publish project with the application.  
   Use publish option by rightclicking the project or by running `dotnet publish` command.  
   Then give appropriate access to users that will be using the website.  
   It usually means that the folder needs to be accessible by users used by IIS:  
   `IIS_USRS` (and maybe `IUSR`).  
   **Note**: if this step is not working, then try to give same permission to `NETWORK`, `NETWORK SERVICE` users

3. Go back to IIS. Create app pool and create website and for physical path just point it to published directory of the project.

4. At last allow inbound traffic in firewall by executing PS command with admin rights:
   ```
   New-NetFirewallRule -DisplayName "Blazor app" -Direction Inbound -LocalPort 9300 -Protocol TCP -Action Allow
   ```
   with appropriate arguments of course.

# Connecting web service (ASP.NET) hosted in Docker from local network

In the Dockerfile for building project container add line `ENV ASPNETCORE_URLS=http://*:443` to allow connections from local network (it will work by connecting to host running Docker and it forwarding the HTTP request down to our container). So complete file looks roughly like

```
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FamilyBudget.WebApp/FamilyBudget.WebApp.csproj", "src/FamilyBudget.WebApp/"]
RUN dotnet restore "src/FamilyBudget.WebApp/FamilyBudget.WebApp.csproj"
COPY . .
WORKDIR "/src/src/FamilyBudget.WebApp"
RUN dotnet build "FamilyBudget.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyBudget.WebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamilyBudget.WebApp.dll"]
```

# Problems:

**Note**: deploying Blazor WASM app.  
**Problem:** Page could not load on first run, and there are errors related to .dat and .blat files (introduced with new blazor app).  
**Solution:** navigate to home in IIS, select "Mime types" and add necessary file extensions with type "application/octet-stream"

# Related posts:

- [Managing firewall with Powershell](https://learn.microsoft.com/en-us/powershell/module/netsecurity/new-netfirewallrule?view=windowsserver2022)
- [Access to folder, when trying to connect throws unauthorized error.](https://stackoverflow.com/questions/28360275/iis-access-to-the-path-is-denied)
- [Adding MIME types to IIS](https://www.trivantis.com/help/CourseMill/7.4/en/Troubleshooting/Content/Troubleshooting_mime.html)
- [Publish an ASP.NET Core app to IIS](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-iis?view=aspnetcore-7.0&tabs=visual-studio)
- [How to do port mapping in docker when running .net core applications](https://stackoverflow.com/questions/58453879/how-to-do-port-mapping-in-docker-when-running-net-core-applications)
