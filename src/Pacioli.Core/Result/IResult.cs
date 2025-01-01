using Microsoft.AspNetCore.Mvc;

namespace Pacioli.Core.Result
{
    public interface IResult
    {
        object? GetValue();

        Type ValueType { get; }

        ProblemDetails? Problem { get; set; }

        bool IsSuccess { get; set; }
    }
}