using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EisenhowerMatrix.Web.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EisenhowerMatrix.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error()
        {
            var errorModel = new ErrorModel();
            errorModel.RequestId = Activity.Current?.Id ?? "";

            return View(errorModel);
        }
    }
}
