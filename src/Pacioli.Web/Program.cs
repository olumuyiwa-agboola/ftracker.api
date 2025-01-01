using Scalar.AspNetCore;
using Pacioli.Web.APIs;
using Pacioli.Core.Services;
using Pacioli.Infrastructure.Factories;
using Pacioli.Infrastructure.Repositories;
using Pacioli.Core.Abstractions.IServices;
using Pacioli.Core.Utilities.Configuration;
using Pacioli.Core.Abstractions.IFactories;
using Pacioli.Core.Abstractions.IRepositories;
using Pacioli.Core.Utilities.Configuration.Sections;

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