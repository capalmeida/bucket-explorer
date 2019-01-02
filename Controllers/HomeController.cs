using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Storage.V1;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace bucketexplorer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
