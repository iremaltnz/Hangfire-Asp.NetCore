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

        public IActionResult PictureSave()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName=String.Empty;

            if (picture != null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                string jobID = BackgroundJobs.DelayedJobs.AddWaterMarkJob(newFileName, "www.mysite.com");

            }

            return View();
        }
    }

   
}
