using Microsoft.OpenApi.Models;
using FinanceTrackerAPI.Core.Utilities.Configuration;
using FinanceTrackerAPI.Core.Utilities.Configuration.Sections;

var builder = WebApplication.CreateBuilder(args);
Documentation documentation = AppSettings.Documentation!;

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        documentation.Name, 
        new OpenApiInfo { 
            Title = documentation.Title,
            Version = documentation.Version,
            Description = documentation.Description,
        }
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Run();
