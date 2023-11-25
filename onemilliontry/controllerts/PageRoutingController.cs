using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.Text.Encodings.Web;

namespace onemilliontry.RoutingController
{
}
    // public class Page:Controller
    // {
    //     public IActionResult Root()
    //     {
    //         return View();
    //     }
    //     public IActionResult Welcome(string name, int numTime=1)
    //     {
    //         ViewData["Message"] = "Hello" + name;
    //         ViewData["NumTimes"] = numTime;
    //         return View();
    //     }
    // }
//     public interface IDateTime
//     {
//         DateTime Now {get;}
//     }

//     public class SystemDateTime:IDateTime{
//         public DateTime Now
//         {
//             get { return DateTime.Now}
//         }
//     }

//     public void ConfigureService(IServiceCollection services)
//     {
//         services.AddSingleton<IDateTime, SystemDateTime>();

//         services.AddControllersWithViews();
//     }

//     public class HomeController : Controller
//     {
//         private readonly IDateTime _datetime;
//         public HomeController(IDateTime dateTime)
//         {
//             _dateTime = dateTime;
//         }
//         public IActionResult Root(){
//             var serverTime = _dateTime.Now;

//             if(serverTime.Hour<12)
//             {
//                 ViewData["Message"] = "It`s morning here - good morning"; 
//             }
//             else if(serverTime.Hour<17)
//             {
//                 ViewData["Message"] = "It`s afternoon here - Good afternoon!";
//             }
//             else 
//             {
//                 ViewData["Message"] = "It`s evening here - Good Evening!";
//             }
//             return View();
//         }
//     }
//     public IActionResult About([FromServices] IDateTime dateTime)
//     {
//         return Content($"Current server time:{dateTiem.Now}");
//     }

//     public class WebSettings
//     {
//         public string Title{get;set;}
//         public int Update {get;set;}
//     }

//     public void ConfigureServices(IServiceCollection services)
//     {
//         services.AddSingleton<IDateTime,SystemDateTime>();
//         services.Configure<SampleWebSettings>(Configuration);
//     }

// }
// public class RootRoutingController : Controller
//     {
        
//         public IActionResult Root(IApplicationBuilder application){
//             var rootpage = application.Map("/root", async(context)=>{
//                 await context.Response.SendFileAsync("cshtml/root.html");
//             });
//             View[rootpage];
//             return View();
//         }
//     }