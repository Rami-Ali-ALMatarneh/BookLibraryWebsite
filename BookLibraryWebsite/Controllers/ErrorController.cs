using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryWebsite.Controllers
    {
    public class ErrorController : Controller
        {
        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
            {
            var exceptionHandlerFeature=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionHandlerFeature.Path;
            ViewBag.ExceptionMassage = exceptionHandlerFeature.Error.Message;
            ViewBag.ExceptionStackTrace=exceptionHandlerFeature.Error.StackTrace;
            return View ("Error");
            }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
            {
            switch (statusCode)
                {
                case 201:
                    ViewBag.StatusCode = "Error 201 Created";
                    break;
                case 204:
                    ViewBag.StatusCode = "Error 204 No Content";
                    break;
                case 400:
                    ViewBag.StatusCode = "Error 400 Bad Request";
                    break;
                case 401:
                    ViewBag.StatusCode = "Error 401 Unauthorized";
                    break;
                case 403:
                    ViewBag.StatusCode = "Error 403 Forbidden";

                    break;
                case 404:
                    ViewBag.StatusCode = "Error 404 Not Found";

                    break;
                case 500:
                    ViewBag.StatusCode = "Error 500 Internal Server Error";
                    break;
                case 502:
                    ViewBag.StatusCode = "Error 502 Bad Gateway";

                    break;
                case 503:
                    ViewBag.StatusCode = "Error 503 Service Unavailable";
                    break;
                default:
                    ViewBag.StatusCode = "Something Wrong!!";
                    break;
                }
            return View("ErrorStatusCode");
            }
        }
    }
