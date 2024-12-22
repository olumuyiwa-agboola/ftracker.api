using Scalar.AspNetCore;
using FinanceTrackerAPI.Web.APIs;
using FinanceTrackerAPI.Core.Utilities.Configuration;
using FinanceTrackerAPI.Core.Utilities.Configuration.Sections;

var builder = WebApplication.CreateBuilder(args);
Documentation documentation = AppSettings.Documentation!;

// Add OpenAPI dependencies
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Set up endpoint for serving OpenAPI document
    app.MapOpenApi();

    // Set up interactive UI for Open API document
    app.MapScalarApiReference(options =>
    {
        options.DefaultFonts = false;
        options.Title = documentation.Title;
    });

    // Redirect for OpenAPI view
    app.MapGet("/", () => Results.Redirect("/scalar/v1"))
        .ExcludeFromDescription();
}

app.UseHttpsRedirection();

// Register /transaction APIs
app.MapTransactionAPIs();

app.Run();