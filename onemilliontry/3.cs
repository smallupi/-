using System.Dynamic;
using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace onemilliontry
{
    // public class Routing{

    //     // public async void RoutingRoot(HttpContext context){
    //     //     if(context.Request.Path == "/root")
    //     //     {
    //     //         Console.WriteLine($"Path: /root Time: {DateTime.Now.ToLongTimeString()}");
    //     //         await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/root.html");
    //     //     }
    //     // }
    // }

    public interface IMyLogger
    {
        void WriteMessage(string message);
    }
    public class MyLogger: IMyLogger
    {
        private readonly ILogger<MyLogger> _logger;
        public MyLogger(ILogger<MyLogger> logger)
        {
            _logger = logger;
        }
        public void WriteMessage(string message)
        {
            _logger.LogInformation($"console logg:{message}");
        }
    }

    
    // public class About: PageModel
    // {
    //     private readonly ILogger _logger;

    //     public About(ILogger<About> logger)
    //     {
    //         _logger = logger;
    //     }

    //     public string Message {get;set;} = string.Empty;
    //     public void OnGet()
    //     {
    //         Message = $"About page visit at:{DateTime.UtcNow.ToLongTimeString()}";
    //         _logger.LogInformation(Message);
    //     }
    // }
    // interface ITimeService{
    //     string GetTime();
    // }
    // class Time:ITimeService
    // {
    //     public string GetTime()=>DateTime.Now.ToShortTimeString();
    // }
    // class TimeMessage
    // {

        
    //     ITimeService time;
    //     public TimeMessage(ITimeService time){
    //         this.time = time;
    //     }
    //     public string GetTime=>$"Time:{time.GetTime()}";
    // }



    //     public class TransferModelProcessToRoot : PageModel
    //     {
        
    //     private readonly ILogger _logger;
    //     private readonly ITimeService _time;

    //     public TransferModelProcessToRoot(ILogger<TransferModelProcessToRoot> logger,
    //                                 ITimeService time){
    //         _logger = logger;
    //         _time = time;
    //     } 
        
    //     public OnGet()
    //     {
    //         _logger.LogInformation("Provider:/root" + _time);
    //     }

    
    //     }
    //    public class TransferToRoot
    //     {
    //     private readonly RequestDelegate _next;
    //     public TransferToRoot(RequestDelegate next)
    //     {
    //         _next = next;
    //     }
    //     public async Task InvokeAsync(IApplicationBuilder applicationBuilder, HttpContext context, ILogger logger)
    //     {
    //         applicationBuilder.UseWhen(context => context.Request.Path == "/time", applicationBuilder =>{
    //             applicationBuilder.Use(async(context, next)=>{
    //              if (context.Request.Path == "/root")
    //                 {
    //                     await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
    //                 }
    //             else await next.Invoke(context);
    //             });
                
    //         });
    //         applicationBuilder.ApplicationServices.GetRequiredService<ILogger<Program>>();
    //         await context.Response.SendFileAsync("/htmlcss/root.html");
            
    //     }
    //     }



    // public static class ReqeustTransferRootExtensions
    // {
    //     public static IApplicationBuilder UseReqeustMiddlewareToRoot(
    //         this IApplicationBuilder builder)
    //     {
    //         return builder.UseMiddleware<TransferToRoot>();
    //     }
    // }


/// <summary>
/// 
/// 
/// </summary>

    public class RootModel : PageModel
    {
        private readonly ILogger _logger;
        private readonly IOperationTrancient _trancientOperation;
        private readonly IOperationSingleton _singeltonOperation;
        private readonly IOperationScoped _scopedOperation;
        
        public RootModel(ILogger<RootModel> logger,
                        IOperationTrancient trancientOperation,
                        IOperationScoped scopedOperation,
                        IOperationSingleton operationSingelton)
        {
            _logger = logger;
            _trancientOperation = trancientOperation;
            _scopedOperation = scopedOperation;
            _singeltonOperation = _singeltonOperation;
        }

        public void OnGet()
        {
            _logger.LogInformation("Trancient:" +_trancientOperation.OperationId);
            _logger.LogInformation("Scoped: " +_scopedOperation.OperationId);
            _logger.LogInformation("Singleton:" + _singeltonOperation.OperationId);
        }
    }
    public interface IOperation
    {
        string OperationId{get;}
    }
    public interface IOperationTrancient: IOperation{}
    public interface IOperationScoped : IOperation{}
    public interface IOperationSingleton: IOperation{}

    public class Operation: IOperationTrancient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }
        public string OperationId{get;}
    }


    /// <summary>
    /// 
    /// </summary>

    public class Service1: IDisposable
    {
        private bool _disposed;
        public void Write(string message)
        {
            Console.WriteLine($"Service 1:{message}");
        }
        public void Dispose()
        {
            if(_disposed)
                return;
            
            Console.WriteLine("Service Disposed 1");
            _disposed = true;
        }
    }

    public class Service2 : IDisposable
    {
        private bool _disposed;
        public void Write(string message)
        {
            Console.WriteLine($"Service 2: {message}");
        }

        public void Dispose()
        {
            if(_disposed)
                return;

            Console.WriteLine("Service Disposed 2");
            _disposed = true;
        }
    }
    public interface IService3
    {
        public void Write(string message);
    }
    public class Service3 : IService3, IDisposable
    {
        private bool _disposed;
        public Service3(string myKey)
        {
            myKey = myKey;
        }
        public string MyKey{get;}
        public void Write(string message)
        {
            Console.WriteLine($"Service 3:{message}, MyKey= {MyKey}");
        }

        public void Dispose()
        {
            if(_disposed)
                return;
            Console.WriteLine("Service Disposed 3");
            _disposed = true;
        }
        public class RootModel: PageModel
        {
            private readonly Service1 _service1;
            private readonly Service2 _service2;
            private readonly IService3 _service3;

            public RootModel(Service1 service1, Service2 service2, IService3 service3){
                _service1 = service1;
                _service2 = service2;
                _service3 = service3;
            }
            public void OnGet()
            {
                _service1.Write("RootModel.OnGet");
                _service2.Write("RootModel.OnGet");
                _service3.Write("RootModel.OnGet");

            }
        }
    }

        // public static RequestDelegate RoutingMarket(HttpContext context){
        //     if(context.Request.Path == "/market")
        //     {
        //         object page = context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/market/market.html");
        //         Console.WriteLine($"Path: /market/market  Time: {DateTime.Now.ToLongTimeString()}");
        //         return;
        //     }
        // }
        // private static RequestDelegate RoutingMarket()
        // {
        //     throw new NotImplementedException();
        // }
    // public static void configuration_database(HttpContext context, IConfiguration applicationConfiguration, IConfigurationSection connectionStrings){
    //     if(context.Request.Path == "/users/api")
    //         connectionStrings(applicationConfiguration);
    //             applicationConfiguration.GetcSection("ConnectionStrings");
    //             string defaultConnection = connectionStrings.GetSection("DefaultConnection").Value;

    //             return defaultConnection;

    // }
    // public class GETSectionConnect(IConfiguration configSection){
    //     System.Text.StringBuilder contentBuilder = new();
    //     foreach(var            section in ConfigSection.GetChildren())
    //     {
    //         contentBuilder.Append($"\"{section.Key\":"});
    //         if(section.Value == null)
    //         {
    //             string subSectionContent = GetSectionContent(section);
    //             contentBuilder.Append($"{{\n{subSectionContent}}},\n");
    //         }
    //         else{
    //             contentBuilder.Append($"\"{section.Value}\",\n")
    //         }
    //     }
    //     return contentBuilder.ToString();
    // }
            
          
}
