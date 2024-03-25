using Hangfire.Web.BackgroundJobs;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp() 
        {
            // ... Codes ...
            FireAndForgetJob.EmailSendToUserJob("userId","Welcome!"); 
            
            return View();
        }
    }

   
}
