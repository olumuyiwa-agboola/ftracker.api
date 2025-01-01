using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Pacioli.Core.Result
{
    public class Error
    {
        public static ProblemDetails NotFound()
        {
            return new ProblemDetails()
            {
                Title = "Record not found",
                Status = (int)HttpStatusCode.NotFound,
            };
        }

        public static ProblemDetails NotFound(string message)
        {
            return new ProblemDetails()
            {
                Title = message,
                Status = (int)HttpStatusCode.NotFound,
            };
        }

        public static ProblemDetails UnprocessableEntity(string message)
        {
            return new ProblemDetails()
            {
                Title = message,
                Status = (int)HttpStatusCode.UnprocessableEntity,
            };
        }

        public static ProblemDetails UnprocessableEntity()
        {
            return new ProblemDetails()
            {
                Title = "An unprocessable entity was passed",
                Status = (int)HttpStatusCode.UnprocessableEntity,
            };
        }
    }
}