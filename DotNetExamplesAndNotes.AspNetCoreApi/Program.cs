using System.Reflection;
using DotNetExamplesAndNotes.AspNetCoreApi.Application.Commands;
using DotNetExamplesAndNotes.AspNetCoreApi.Application.Queries;
using DotNetExamplesAndNotes.WebApiDAL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDal();

var app = builder.Build();

// Custom middleware.
app.Use(async (HttpContext context, Func<Task> task) =>
{
    context.Response.Headers.TryAdd("custom-header-middleware", "a-value");
    await task.Invoke();
});

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WebApiContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getblogs", async ([FromServices] IMediator mediator) =>
{
    return Results.Ok(await mediator.Send(new GetBlogsQuery()));
})
.WithName("GetBlogs")
.WithOpenApi();

app.MapPost("/addblog", async ([FromServices] IMediator mediator) =>
{
    await mediator.Send(new CreateBlogCommand());
    return Results.Ok();
})
.WithName("AddBlog")
.WithOpenApi();

app.Run();
