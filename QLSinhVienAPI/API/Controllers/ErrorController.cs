using System.Reflection.Metadata.Ecma335;
using API.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/error")]
    public class ErrorController : ControllerBase
    {
        [Route("")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = context?.Error;
            var response = new BaseResponse<object>(
                new
                {
                    errorMessage = error?.Message ?? "Lỗi không xác định",
                    details = error?.StackTrace
                },
                error?.Message ?? "Lỗi không xác định",
                false
            );
            var statusCode = error switch
            {
                ArgumentNullException => 400, // Bad Request
                ArgumentException => 400, // Bad Request
                UnauthorizedAccessException => 401, // Unauthorized
                KeyNotFoundException => 404, // Not Found
                _ => 500 // Internal Server Error
            };
            return StatusCode(statusCode, response);
        }
    }
}