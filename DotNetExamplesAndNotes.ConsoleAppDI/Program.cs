// See https://aka.ms/new-console-template for more information
using DotNetExamplesAndNotes.ConsoleAppDI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = CreateHost();

var logger = host.Services.GetService<ILogger>();
logger.Information("Successfully created logger");

var service = ActivatorUtilities.CreateInstance<NumberService>(host.Services);
var number = service.GetNumber();
logger.Information($"Number from number service: {number}");

var numRepo = ActivatorUtilities.CreateInstance<NumberRepository>(host.Services);
var numberFromConfig = numRepo.GetNumber();
logger.Information($"Number from number repository (from config): {numberFromConfig}");

logger.Error("This is ERROR LOG");

static IHost CreateHost() => Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services
                .AddSingleton<INumberService, NumberService>()
                .AddSingleton<INumberRepository, NumberRepository>()
                .Configure<NumberConfig>(context.Configuration.GetSection("Number"));
        })
        .UseSerilog((context, services, configuration) => 
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console())
        .Build();


