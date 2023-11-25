using System.Diagnostics;
using Microsoft.AspNetCore.Http;
namespace onemilliontry
{
    /// <summary>
    /// 
    /// </summary>
    class RoutingToRootMiddleware{
	    private readonly RequestDelegate next;
	
	    public RoutingToRootMiddleware(RequestDelegate next){
		this.next = next;	
	    }
	    public async Task InvokeAsync(HttpContext context)
	    {
		    if(context.Request.Path =="/root"){
			    // await context.Response.WriteAsJsonAsync(timeService);
			    // await next.Invoke();
			    await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/root.html");
		    }
            else await next.Invoke(context);
		
	    }
    }
    public class ReqeustLoggerMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ReqeustLoggerMiddelware(RequestDelegate next, ILoggerFactory loggerDactory){
            _next = next;
            _logger = loggerDactory.CreateLogger<ReqeustLoggerMiddelware>();    
        }
        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling reqeust: "+ context.Request.Path);
            await _next.Invoke(context);
            _logger.LogInformation("Finished handling request.");
        }
    }
    public static class ReqeustLoggerExtensions{
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReqeustLoggerMiddelware>();
        }
    }
    
    // public void ConfigureLogMiddleware(IApplicationBuilder application, ILoggerFactory loggerfactory)
    // {
    //     loggerfactory.AddConsole(minlevel:LogLevel.Information);
    //     application.UseRequestLogger();
    //     application.Run(async context =>{

    //     });
    // }


    // class RoutingToMarketMiddleware{
    //     private readonly RequestDelegate next;
    //     public RoutingToMarketMiddleware(RequestDelegate next){
    //         this.next = next;
    //     }
    //     public async Task InvokeAsync(HttpContext context)
    //     {
    //         if(context.Request.Path == "/market"){
                
    //             Console.WriteLine($"Path: /market/market  Time: {DateTime.Now.ToLongTimeString()}");
    //             await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/market/market.html");
    //         }
    //     }
    // }
    /// <summary>
    /// 
    /// </summary>
    // class TimeMessageMiddelware {
    //     private readonly RequestDelegate next;
    //     int count = 0;
    //     ITimeService timeService;
    //     public TimeMessageMiddelware(RequestDelegate next, ITimeService timeService)
    //     {
    //         this.next = next;
    //         this.timeService = timeService;
    //     }
    //     public async Task InvokeAsync(HttpContext context, ITimeService timeService)
    //     {

    //         if (context.Request.Path == "/time")
    //         {
    //             //var timeService = application.Services.GetService<ITimeService>();
    //             var time = DateTime.Now.ToShortDateString();
    //             //var TimeToConsole = context.RequestServices.GetService<TimeMessage>();
    //             //var form = context.Request.Form["Time"];
    //             //form = time;
    //             //Console.WriteLine(TimeToConsole);
    //             await context.Response.WriteAsJsonAsync(timeService);
    //         }
    //         else
    //         {
    //             await next.Invoke(context);
    //         }


    //         //context.Response.WriteAsJsonAsync(timeService.GetTime());
    //     }
    // }
    public class TimerMiddleware
    {
        TimeService timeService;
        public TimerMiddleware(RequestDelegate next, TimeService timerService)
        {
            this.timeService = timerService;
        }
        public async Task Invoke(HttpContext context){
            await context.Response.WriteAsJsonAsync(timeService);
        }
    }

    class GeneratorMiddleware
    {
        RequestDelegate next;
        IGenerator generator;

        public GeneratorMiddleware(RequestDelegate next, IGenerator generator)
        {
            this.next = next;
            this.generator = generator;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path == "/generate")
            await context.Response.WriteAsJsonAsync(generator.GenerateValue);
            else await next.Invoke(context);
        }
    }
    // class GETUser{
    //     RequestDelegate next;
        
    // }
    
    // class GetSectionJSONContent{
        
    //     RequestDelegate next;
    //     IConfiguration  configurationSection;
    //     public  GetSectionJSONContent(IConfiguration configurationSection, RequestDelegate next){
    //         this.next = next;
    //         this.configurationSection = configurationSection;
    //     }
    //     public async Task InvokeAsync(IConfiguration configurationSection, HttpContext context){
            
    //     }

    //     public string GetSectionJSONContent(IConfigurationSection section)
    //     {
    //         if(context.Request.Path == "/configuration"){
    //             System.Text.StringBuilder contentBuilder = new();
    //             foreach(var section in configurationSection.GetChildren())
    //             {
    //                 contentBuilder.Append($"\"{section.Key}\":");
    //                 if(section.Value == null){
    //                     string subSectinContent = GetSectionJSONContent(section);
    //                     contentBuilder.Append($"{{\n{subSectionContent}}},\n");
    //                 }
    //                 else
    //                 {
    //                     contentBuilder.Append($"\"{section.Value}\",\n");
    //                 }
    //             }
    //             return contentBuilder.ToString();
    //         }
    //     }
    // }


    // public class ReaderMiddleware{
    //     IReader reader;
    //     public ReaderMiddleware(RequestDelegate _, IReader reader)
    //     {
    //         this.reader = reader;
    //     }

    //     public  async Task InvokeAsync(HttpContext context){
    //         await context.Response.WriteAsJsonAsync(reader.ReadValue());
    //     }
    // }
    
}