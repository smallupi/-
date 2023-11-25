using System.ComponentModel;
using Microsoft.Extensions.Options;
using onemilliontry;

namespace onemilliontry
{
    public class TransferToRoot
    {
        private readonly RequestDelegate _next;
        public TransferToRoot(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(IApplicationBuilder applicationBuilder, HttpContext context, ILogger logger)
        {
            applicationBuilder.UseWhen(context => context.Request.Path == "/time", applicationBuilder =>{
                applicationBuilder.Use(async(context, next)=>{
                 if (context.Request.Path == "/root")
                    {
                        await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
                    }
                else await next.Invoke(context);
                });
                
            });
            applicationBuilder.ApplicationServices.GetRequiredService<ILogger<Program>>();
            await context.Response.SendFileAsync("/htmlcss/root.html");
            
        }
    }
    public static class ReqeustTransferRootExtensions
    {
        public static IApplicationBuilder UseReqeustMiddlewareToRoot(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransferToRoot>();
        }
    }


    public class TransferToForum
    {
        private readonly RequestDelegate _next;
        public TransferToForum(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(IApplicationBuilder applicationBuilder, HttpContext context, ILogger logger)
        {
            applicationBuilder.UseWhen(context => context.Request.Path == "/time", applicationBuilder =>{
                applicationBuilder.Use(async(context, next)=>{
                 if (context.Request.Path == "/forum")
                    {
                        await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
                    }
                else await next.Invoke(context);
                });
                
            });
            applicationBuilder.ApplicationServices.GetRequiredService<ILogger<Program>>();
            await context.Response.SendFileAsync("/htmlcss/forum.html");
            
        }
    }
    public static class ReqeustTransferForumExtensions
    {
        public static IApplicationBuilder UseReqeustMiddlewareToForum(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransferToForum>();
        }
    }
}


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

   