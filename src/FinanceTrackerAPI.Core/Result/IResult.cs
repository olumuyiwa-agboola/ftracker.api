using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Core.Result
{
    public interface IResult
    {
        object? GetValue();

        Type ValueType { get; }

        ProblemDetails? Problem { get; set; }

        bool IsSuccess { get; set; }
    }
}