using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnAspCore.Controllers
{
    public class ErrorController : Controller
    {


        public ErrorController(ILogger<ErrorController> logger)
        {
            LoggerObjetct = logger;
        }

        private ILogger<ErrorController> LoggerObjetct { get; set; }


        [Route("Error/{StatusCode}")]
        public IActionResult StatusCodeHandle(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessasge = $"I am having {statusCode}" +" Error code Message";
                    break;
                    
            }
            return View(statusCode);
        }


        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionFeature.Path+"\n";
            ViewBag.ExceptionMessage = exceptionFeature.Error.Message;
            ViewBag.StackTrace = exceptionFeature.Error.StackTrace;
            LoggerObjetct.LogError($"The Path is {exceptionFeature.Path} and Error Message {exceptionFeature.Error.Message} and StackTrace {exceptionFeature.Error.StackTrace}");

            return View();

        }

    }
}