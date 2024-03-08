using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
		public ILogger<ErrorController> _logger { get; }
		public ErrorController(ILogger<ErrorController> logger)
        {
			_logger = logger;
		}

		

		[Route("Error/{statusCode}")]

        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
         var statusCodeResult=   HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requisted could not be found";
                    _logger.LogWarning($"404 Error Occured. Path={statusCodeResult.OriginalPath}" +
                        $"and QueryString ={statusCodeResult.OriginalQueryString}");
                    //ViewBag.Path = statusCodeResult.OriginalPath;
                    //ViewBag.QueryString = statusCodeResult.OriginalQueryString;
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, the resource you requisted could not be found";

                    break;
            }
            return View("NotFound");
        }
    }
}
