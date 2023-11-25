using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace onemilliontry
{
    public class Home2Controller:Controller
    {
        private readonly ILogger<Home2Controller> _logger;

        public Home2Controller(ILogger<Home2Controller> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }
        [EnableRateLimiting("sliding")]
        public ActionResult Privacy()
        {
            return View();
        }
        [DisableRateLimiting]
        public ActionResult NoLimiting()
        {
            return View();
        }
        
    }
}