using Microsoft.AspNetCore.Mvc;

namespace Pacioli.Core.Result
{
    public class Result<T> : IResult
    {
        #region Constructors
        public Result(T value)
        {
            Value = value;
            Problem = null;
            IsSuccess = true;
        }

        public Result(ProblemDetails problem)
        {
            Value = default;
            IsSuccess = false;
            Problem = new ProblemDetails()
            {
                Title = problem.Title,
                Status = problem.Status,
            };
        }
        #endregion

        #region Implicit operators
        public static implicit operator Result<T>(T value) => new(value);

        public static implicit operator Result<T>(ProblemDetails problem) => new(problem);
        #endregion

        #region Public properties
        public T? Value { get; set; }

        public ProblemDetails? Problem { get; set; }

        public bool IsSuccess { get; set; }

        public Type ValueType => typeof(T);
        #endregion

        #region Public methods
        public object? GetValue() => Value;
        #endregion
    }
}