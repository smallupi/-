using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
// using onemilliontry.configuration;

// public class RootModel : PageModel
// {
//     private IConfigurationRoot ConfigRoot;

//     public RootModel(IConfigurationRoot configurationRoot)
//     {
//         ConfigRoot = configurationRoot;
//         //ConfigRoot =(IConfigurationRoot)configurationRoot;
//     }
//     public ContentResult OnGet()
//     {
//         var myKeyValue = ConfigRoot["myKey"];
//         var title = ConfigRoot["Position:Title"];
//         var name = ConfigRoot["Position:Name"];
//         var defaultLogLevel = ConfigRoot["Logginig:LogLevel:Default"];
//         _logger.LogInformation("RootPage visited at {DT}",
//             DateTime.UtcNow.ToLongTimeString());

//         return Content($"MyKey value: {myKeyValue}\n" +
//                         $"Title:{title}\n" +
//                         $"Name:{name}\n" +
//                         $"Default Log Level: {defaultLogLevel}");


//         // string content ="";
//         // foreach (var provider in ConfigRoot.Providers.ToList())
//         // {
//         //     content += provider.ToString()+"\n";
//         // }

//         //return Content(content);
//     }

//     private readonly ILogger _logger;

//     public RootModel(ILogger<RootModel> logger)
//     {
//         _logger = logger;
//     }
    
// }
public class MyLogECents
{
    public const int GenereItems = 1000;
    public const int ListItems = 1001;
    public const int GetItem = 1002;
    public const int InsertItem = 1003;
    public const int UpdateItem = 1004;
    public const int DeleteItem = 1005; 
    public const int TesItem = 3000;
    public const int GetItemNotFound = 4000;
    public const int UpdateItemNotFound = 4001;
}

// public class StartupBackgroundService: BackgroundService{
//     private readonly StartupHealthCheck _healthCheck;
//     public bool StartupCompleted
//     {
//         get => _isReady;
//         set => _isReady = value;
//     }
//     public StartupBackgroundService(StartupHealthCheck healthCheck)
//         => _healthCheck = healthCheck;
//     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//     {
//         await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
//         _healthCheck.StartupCompleted = true;
//     }
// }
