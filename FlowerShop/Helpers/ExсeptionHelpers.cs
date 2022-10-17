using System.Net;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace FlowerShop.Helpers
{
    public static  class ExсeptionHelpers<T> where T: Exception
    {
        public static ProblemDetails MapToProblemDetails(T ex)
        {
            if (ex.GetType() == typeof(HttpOperationException))
            {
                var httpOperationException = (HttpOperationException)(object)ex;
                try
                {
                    return JsonConvert.DeserializeObject<ProblemDetails>(httpOperationException.Response.Content);

                }
                catch
                {
                    return new ProblemDetails
                    {

                        Title = ex.Message,
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = ex.GetType().ToString(),
                    };
                }
            }

            return new ProblemDetails()
            {
                Title = MapExceptionDetailsToString(ex),
                Status = StatusCodes.Status400BadRequest,
                Type = ex.GetType().ToString(),

            };

        }
        internal static string MapExceptionDetailsToString(Exception ex)
        {
            return ex switch
            {
                FluentValidation.ValidationException validationException => string.Join(";",
                    validationException.Errors
                        .Select(e => e.ErrorMessage).ToArray()),
                _ => ex.Message
            };
        }
    }
}
