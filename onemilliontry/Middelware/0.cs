using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Identity.Client;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace onemilliontry
{
    // [Route("[controller]/[action]")]
    // public class HomeController:Controller
    // {
    //     [Route("")]
    //     [Route("Root")]
    //     [Route("Market")]
    //     [Route("Registration")]
    //     [Route("Authoriztion")]
    //     public IActionResult Root(){ return ControllerContext.MyDisplayRouteInfo();}
    // }
    // [Route("api/[controller]")]
    // [ApiController]
    // public class TransferController:ControllerBase
    // {
    //     [HttpGet]
    //     public IActionResult ListProducts()
    //     {
    //         return ControllerContext.MyDisplayRouteInfo();
    //     }
    //     [HttpGet("id")]
    //     public IActionResult GetProduct(string id)
    //     {
    //         return ControllerContext.MyDisplayRouteInfo(id);
    //     }
    // }
    // [Route("root/[controller]")]
    // public class MiddelwareRoutingToRoot
    // {
    //     void HadleMiddelwareRoutingToRoot(IApplicationBuilder application)
    //     {
    //         var logger = application.ApplicationServices.GetRequiredService<ILogger<Program>>();
    //         application.Use(async(context ,next)=>{
    //             var branchVer= context.Request.Query["root"];
    //             logger.LogInformation("Branch user = {branchVer}", branchVer);
    //             await next.Invoke(context);
    //         });
    //         application.Use(async(context, next)=>{
    //             if(context.Request.Path =="/root"){
	// 		        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/root.html");
	// 	        }
    //             else await next.Invoke(context);
    //         });
    //         application.UseWhen(context => context.Request.Path == "/time", applicationBuilder =>{
    //             application.Use(async(context, next)=>{
    //              if (context.Request.Path == "/root")
    //                 {
    //                     await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
    //                 }
    //             else await next.Invoke(context);
    //             });     
    //         });
    //     }
    // }
        // [Fact]
        // public async Task MiddlewareTest_ReturnsNotFoundForRequest()
        // {
        //     using var host  = await new HostBuilder()
        //         .ConfigureWebHost(WebHostBuilder =>{
        //             WebHostBuilder
        //             .UseTestServer()
        //             .ConfigureService(services=>{
        //                 services.AddMyServices();
        //             }).Configure(application=>{
        //                 application.UseMiddleware<MyMiddleware>();
        //             });
        //     }).StartAsync();
        //     //var response = await host.GetTestClient().GetAsync("/");
        //     //AssertionRequestOptions.NotEqual(HttpStatusCode.NotFound, response.StatusCode);
        //     var server = host.GetTestServer();
        //     server.BaseAddress = new Uri("https://example.com/A/Path");

        //     var context =await server.SendAsync(ServerContext=>{
        //         ServerContext.reqeust.Method = HttpMethods.Post;
        //         ServerContext.Request.Path ="/and/file.txt";
        //         ServerContext.Request.QueryString = new QueryString("?and=query");
        //     });
        //     Assert.True(context.ReqeustAborted.CanBeCanceled);
        //     Assert.Equal(HttpProtocol.Http11, context.Request.Method);
        //     Assert.Equal("POST", context.Request.Method);
        //     Assert.Equal("https", context.Request.Cheme);
        //     Assert.Equal("example.com", context.Request.Host.Value);
        //     Assert.Equal("/A/Path", context.Request.PathBase.Value);
        //     Assert.Equal("/and/file.txt", context.Request.Path.Value);
        //     Assert.Equal("?and=query", context.Request.QueryString.Value);
        //     Assert.NotNull(context.Request.Body);
        //     Assert.NotNull(context.Request.Headers);
        //     Assert.NotNull(context.Response.Headers);
        //     Assert.NotNull(context.Response.Body);
        //     Assert.Equal(404, context.Response.StatusCode);
        //     Assert.Null(context.Feature.Get<IHttpResponseFeature>().ReasonPhrase);
        // }




    
    public class RoutingPages
    {
        public interface IOperation
        {
            string OperationId{get;}
        }
        public interface IOperationSingleton: IOperation{}


        private readonly RequestDelegate _next;
        private readonly ILogger  _logger;
        private readonly IOperationSingleton _singeltonOperation;

        public RoutingPages(RequestDelegate next, ILogger<RoutingPages>logger,
            IOperationSingleton singeltonOperation)
        {
            _logger = logger;
            _singeltonOperation = singeltonOperation;
            _next = next; 
        }
        public async Task InvokeAsync(HttpContext context, 
            IOperationTrancient trancientOperation, IOperationScoped scopedOpearion)
        {
            _logger.LogInformation("Trancient:" + trancientOperation.OperationId);
            _logger.LogInformation("Scoped:" + scopedOpearion.OperationId);
            _logger.LogInformation("Singleton"+_singeltonOperation.OperationId);

            await _next(context);
        }
    }
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingPages>();
        }
    }
    public static class MiddlewareTransferToRoot
    {

        public static void ToRoot(IApplicationBuilder applicationBuilder, HttpContext context)
        {
            applicationBuilder.Use(async(context, next)=>{
                if(context.Request.Path =="/root"){
			        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/root.html");
		        }
                else await next.Invoke(context);
            });
            // applicationBuilder.Run("/root", async(context)=>{
            //     await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/root.html");
            // });
        }
        public static IApplicationBuilder UseTransfferMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingPages>();
        }
    }
    
}
