using Application;
using Infrastructure;
using Web.API;
using Web.API.Extensions;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Arch V2"));
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();