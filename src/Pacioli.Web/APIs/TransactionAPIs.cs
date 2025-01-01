using System.Net;
using Microsoft.AspNetCore.Mvc;
using Pacioli.Core.Models;
using Pacioli.Core.Abstractions.IServices;

namespace Pacioli.Web.APIs
{
    public static class TransactionAPIs
    {
        public static IEndpointRouteBuilder MapTransactionAPIs(this IEndpointRouteBuilder app)
        {
            var transactions = app.MapGroup("api/transactions")
                .WithTags("Transactions")
                .WithDescription("APIs for managing transactions.");

            transactions.MapGet("/", async (ITransactionsService service) => HandleResult(await service.GetAllTransactions()))
                .WithName("GetAllTransactions")
                .WithSummary("Get all transactions")
                .WithDescription("Retrieves the list of all transactions.")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<List<Transaction>>((int)HttpStatusCode.OK);

            transactions.MapGet("/{id}", async ([FromRoute] string id, ITransactionsService service) => HandleResult(await service.GetTransaction(id)))
                .WithName("GetTransactionById")
                .WithSummary("Get a transaction")
                .WithDescription("Retrieves the details of the transaction whose id is specified in the route.")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<ProblemDetails>((int)HttpStatusCode.NotFound)
                .Produces<Transaction>((int)HttpStatusCode.OK);

            transactions.MapPost("/", async ([FromBody] CreateTransactionRequest request, ITransactionsService service) => HandleResult(await service.CreateTransaction(request)))
                .WithName("CreateTransaction")
                .WithSummary("Create a transaction")
                .WithDescription("Creates a new transaction using the information passed in the request body.")
                .Produces<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<CreateTransactionResponse>((int)HttpStatusCode.OK);

            transactions.MapPut("/{id}", async ([FromRoute] string id, UpdateTransactionRequest request, ITransactionsService service) => HandleResult(await service.UpdateTransaction(request)))
                .WithName("UpdateTransaction")
                .WithSummary("Update a transaction")
                .WithDescription("Updates the details of a transaction whose id is specified in the route with the information passed in the request body.")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)
                .Produces<UpdateTransactionResponse>((int)HttpStatusCode.OK);

            transactions.MapDelete("/{id}", async ([FromRoute] string id, ITransactionsService service) => HandleResult(await service.DeleteTransaction(id)))
                .WithName("DeleteTransaction")
                .WithSummary("Delete a transaction")
                .WithDescription("Deletes a transaction whose id is specified in the route.")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)
                .Produces<DeleteTransactionResponse>((int)HttpStatusCode.OK);

            return app;
        }

        private static IResult HandleResult<TResult>(TResult result) where TResult : Core.Result.IResult
        {
            return result.IsSuccess switch
            {
                true => Results.Ok(result.GetValue()),
                false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
            };
        }
    }
}