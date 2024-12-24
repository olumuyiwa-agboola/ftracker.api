using Scalar.AspNetCore;
using FinanceTrackerAPI.Web.APIs;
using FinanceTrackerAPI.Core.Services;
using FinanceTrackerAPI.Infrastructure.Factories;
using FinanceTrackerAPI.Infrastructure.Repositories;
using FinanceTrackerAPI.Core.Abstractions.IServices;
using FinanceTrackerAPI.Core.Utilities.Configuration;
using FinanceTrackerAPI.Core.Abstractions.IFactories;
using FinanceTrackerAPI.Core.Abstractions.IRepositories;
using FinanceTrackerAPI.Core.Utilities.Configuration.Sections;

var builder = WebApplication.CreateBuilder(args);
Documentation documentation = AppSettings.Documentation!;

// OpenAPI dependencies
builder.Services.AddOpenApi();

// Domain services and repositories
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Endpoint for serving OpenAPI document
    app.MapOpenApi();

    // Interactive UI for Open API document
    app.MapScalarApiReference(options =>
    {
        options.DefaultFonts = false;
        options.Title = documentation.Title;
    });

    // Redirection to interactive view
    app.MapGet("/", () => Results.Redirect("/scalar/v1"))
        .ExcludeFromDescription();
}

app.UseHttpsRedirection();

// Registration of /transaction APIs
app.MapTransactionAPIs();

app.Run();