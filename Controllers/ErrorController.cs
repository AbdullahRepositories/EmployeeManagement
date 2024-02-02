using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]

        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
         var statusCodeResult=   HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requisted could not be found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QueryString = statusCodeResult.OriginalQueryString;
                    break;
                default:
                    break;
            }
            return View("NotFound");
        }
    }
}
