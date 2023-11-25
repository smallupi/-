using System.IO.Compression;
using System.Collections.Immutable;
using System.Security.Authentication.ExtendedProtection;
using System.Diagnostics;
using System.Net.Mime;
using Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Azure.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.ResponseCompression;
using System.Globalization;
using Microsoft.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Connections;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.RateLimiting;
using Middleware.Example;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore;

namespace onemilliontry
{

    public class Program
    {

        public static void Main(String[] args)
        {

            var create = WebApplication.CreateBuilder(args);
            // var create = WebApplication.CreateBuilder(new WebApplicationOptions
            // {
            //     Args = args,
            //     WebRootPath = "htmlcss"
            // });
            //


            
            //conffig
            var WebHostApplicationConfiguration = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration
            ((hostingContext, config) =>
            {
                config.AddXmlFile("applicationsettings.xml", optional: true, reloadOnChange: true);
            });

            var WebHostLogginig = WebHost.CreateDefaultBuilder(args).ConfigureLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Warning);
            });
            WebHost.CreateDefaultBuilder(args)
                .UseSetting(WebHostDefaults.ApplicationKey, "CustomApplicationName");
            WebHost.CreateDefaultBuilder(args).CaptureStartupErrors(true);





            //conffig to https
            create.WebHost.ConfigureKestrel(options =>
            {
                options.ConfigureHttpsDefaults(httpsOptions =>
                {
                    var CertPath = Path.Combine(create.Configuration["Kestrel:Certificates:Default:Path"] = "cert.pem");
                    var KeyPath = Path.Combine(create.Configuration["Kestrel:Certificates:Default:KeyPath"] = "key.pem");
                    httpsOptions.ServerCertificate = X509Certificate2.CreateFromPemFile(CertPath, KeyPath);
                });
            });

            create.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(30));
            create.WebHost.UseHttpSys();
            //loginig whe json fromat string file 
            //create.Logging.AddJsonConsole();

            create.Services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });

            create.Services.AddRequestDecompression();
            create.Services.AddScoped<IMyLogger, MyLogger>();

            create.Services.AddRazorPages();

            ///
            // create.Services.AddTransient<IOperationTrancient, Operation>();
            // ///
            // create.Services.AddScoped<IOperationScoped, Operation>();
            // create.Services.AddSingleton<IOperationSingleton, Operation>();
            

            // create.Services.AddSingleton(new Service1());
            // create.Services.AddSingleton(new Service2());
            // // logger to middelware
            // create.Services.AddScoped<Service1>();
            // create.Services.AddSingleton<Service2>();

            // var myKey = create.Configuration["MyKey"];
            // create.Services.AddSingleton<IService3>(Span => new Service3(myKey));
            
            create.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

            });
            create.Services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            create.Services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });


            create.Services.AddHttpClient();
            



            // using(var scope = application.Services.Create.Scope())
            // {
            //     var service = scope.ServiceProvider;
            //     SeedData.Initialize(services);
            // }
            // create.Services.AddRazorPages();
            // create.Services.AddDbContext<UserDBModel>(options => 
            //     options.UseSqlServer(create.Configuration
            //      .GetConnectionString("Data Source=(localdb)/MSSQLLocalDB;Initial Catalog=onemilliontry;Integrated Security=True;TrusServerCertificate=True;")
            //      ?? throw new InvalidOperationException("Connection string razot page not found")));

            

            create.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            var cashe = create.Services.AddDistributedMemoryCache();
            var session = create.Services.AddSession();


            var application = create.Build();
            //
            
            application.MapRazorPages();
            


            using (var serviceScope = application.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var myLogger = services.GetRequiredService<IMyLogger>();
                myLogger.WriteMessage("call services from main");
            }

            // template to 
            //application.UseReqeustMiddlewareToRoot();
            //application.UseMiddleware<TransferToRoot>();
            // mapping root
            //application.UseReqeustMiddlewareToForum();
            //application.UseMiddleware<TransferToForum>();
            // mapping forum


            // don`t say 
            application.UseStatusCodePages(async statusCodeContext =>
            {
                var Response = statusCodeContext.HttpContext.Response;
                var path = statusCodeContext.HttpContext.Request.Path;
                Response.ContentType = "text";
                if (Response.StatusCode == 403)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error403.html");
                }
                else if (Response.StatusCode == 404)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error404.html");
                }
                else if (Response.StatusCode == 500)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error500.html");
                }
                else if (Response.StatusCode == 400)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error400.html");
                }
                else if (Response.StatusCode == 401)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error401.html");
                }
                else if (Response.StatusCode == 402)
                {
                    await Response.SendFileAsync("onemilliontry/htmlcss/error/error402.html");
                }
            });
            ////////

            var loggerFactory = LoggerFactory.Create(create =>
            {
                create.ClearProviders();
                create.AddDebug();
                create.AddConsole();
                //create.AddEventLog();
                create.AddFilter("System", LogLevel.Debug)
                    .SetMinimumLevel(LogLevel.Debug);
                // .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            });
            ILogger logger = loggerFactory.CreateLogger("WebApplication");

            // SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            // connectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=onemilliontry;Integrated Security=True;TrusServerCertificate=True;";
            // connectionString.DataSource="<LIGHT\\SQLEXPRESS01>";
            // connectionString.UserID="<>";
            // connectionString.Password="<>";
            // connectionString.InitialCatalog="<onemilliontry>";
            // using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            // {
            //     logger.LogInformation($"SqlConnection is open !");
            //     string sql = "SELECT onemilliontry, Users FROM onemilliontry";
            //     using (SqlCommand command = new SqlCommand(sql, connection))
            //     {
            //         connection.Open();
            //         using(SqlDataReader reader = command.ExecuteReader())
            //         {
            //             while(reader.Read())
            //             {
            //                 logger.LogInformation("{0} {1}", reader.GetString(0), reader.GetString(1));

            //             }
            //         }
            //     }
            // }


            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add($"htmlcss/root.html");

            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"htmlcss")),
                RequestPath = new PathString("/htmlcss"),
            });
            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"database")),
                RequestPath = new PathString("/database")
            });
            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"database")),
                RequestPath = new PathString("/database")
            });
            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"services")),
                RequestPath = new PathString("/service")
            });
            application.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"configuration")),
                RequestPath = new PathString("/configuration")
            });
            application.UseDefaultFiles();
            application.UseRateLimiter();
            application.UseHttpsRedirection();
            application.UseStaticFiles();
            application.UseResponseCaching();
            application.UseAuthentication();
            //application.UseAuthorization();
            //application.MapRazorPages();
            application.UseSession();
            application.UseCookiePolicy();
            application.UseRouting();
            application.UseRequestCulture();
            application.UseFileServer();
            application.UseRequestDecompression();
            
            application.UseMiddleware<ReqeustCultureMiddleware>();
            //application.UseMiddleware<RoutingPages>();

            // application.MapControllerRoute
            // (name:"default", 
            // pattern:"{controller=Home}/{action=Root}/{id?}");
            
            //application.UseMyMiddleware();
            application.UseResponseCompression();

            application.UseWhen(context => context.Request.Path == "/time", applicationBuilder =>
            {
                applicationBuilder.Use(async (context, next) =>
                {
                    await next();
                });
                applicationBuilder.Run(async context =>
                {
                    if (context.Request.Path == "/root")
                    {
                        var timeService = application.Services.GetService<TimeService>();

                        await context.Response.WriteAsJsonAsync(timeService);
                    }
                    await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
                });
            });

            application.Use(async (context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }
                await next(context);
            });
            application.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders()
                    .CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(30)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };
                await next(context);
            });


            application.MapGet("/", () => DateTime.Now.Millisecond);

            /// <summary>
            /// 
            /// </summary>
            /// <value></value>
            

            application.Map(
                "/root", applicationBuilder =>
                {

                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Path: htmlcss/RootPage/root  Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("htmlcss/RootPage/root.html");
                        //await context.Response.SendFileAsync("htmlcss/root.cshtml");
                    });
                });


            /// <summary>
            /// market
            /// </summary>
            /// <value></value>
            application.Map(
                "/product", applicationBuilder =>
                {
                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Request Path:{context.Request.Path}");
                        logger.LogInformation($"Path: /market/product  Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/market/product.html");
                    });
                });
            /// <summary>
            /// product
            /// </summary>
            /// <value></value>
            application.Map(
                "/market", applicationBuilder =>
                {
                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Request Path:{context.Request.Path}");
                        logger.LogInformation($"Path: /market/market  Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/market/market.html");
                    });
                });

            // application.Map("/market",RoutingMarket())
            /// <summary>
            /// authorization
            /// </summary>
            /// <value></value>

            application.Map(
                "/authorization/user", applicationBuilder =>
                {
                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Request Path:{context.Request.Path}");
                        logger.LogInformation($"Path: /api/authorization/user  Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/authorizationuser.html");
                    });
                });

            /// <summary>
            /// registration
            /// </summary>
            /// <value></value>
            application.Map(
                "/registration/user", applicationBuilder =>
                {
                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Path: result/registration/user Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/registrationuser.html");
                    });
                });
            application.MapGet("result/registration/user", async (context) =>
            {
            });
            /// <summary>
            /// 
            /// </summary>
            /// <value></value>
            application.UseWhen(context => context.Request.Path == "/registration/user", applicationBuilder =>
            {
                applicationBuilder.Use(async (context, next) =>
                {
                    context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcss/registrationuser.html");
                    await next.Invoke();
                });
                applicationBuilder.Run(async context =>
                {
                    if (context.Request.Path == "/registration/user/api")
                    {
                        //await CreateUser(context.Request, context.Response);
                    }
                    //await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
                });
            });
            /// <summary>
            /// 
            /// </summary>
            /// <value></value>
            application.Map(
                "/registration/user/table", applicationBuilder =>
                {
                    applicationBuilder.Run(async context =>
                    {
                        logger.LogInformation($"Request Path:{context.Request.Path}");
                        logger.LogInformation($"Path: /registration/user   Time: {DateTime.Now.ToLongTimeString()}");
                        await context.Response.SendFileAsync("E:/Projects-OnemillionTry/WApplication/onemilliontry/htmlcs/testingdataapi/getuser.html");
                    });
                });
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            application.Map("/download_Methods_HTTP_Txt", async () =>
            {
                string path = "E:/Projects-OnemillionTry/WApplication/onemilliontry/AnoutherFiles/HTTPMethods.txt";
                byte[] fileContent = await File.ReadAllBytesAsync(path);
                string ContentType = "TXT";
                string downloadName = "http_methods.txt";
                return Results.File(fileContent, ContentType, downloadName);
            });

            application.Map("/trickle", async (HttpResponse httpresponse) =>
            {
                httpresponse.ContentType = "text/plain;charser=utf-8";

                for (int i = 0; i < 20; i++)
                {
                    await httpresponse.WriteAsync("a");
                    await httpresponse.Body.FlushAsync();
                    await Task.Delay(TimeSpan.FromMilliseconds(50));
                }
            });

            

            application.Urls.Add("http://localhost:3000");
            application.Urls.Add("http://localhost:4000");
            application.Urls.Add("http://localhost:5000");
            // application.Urls.Add("http://onemilliontry:1111");
            application.Logger.LogInformation("application is worked");


            
            //application.MapControllers();

            //application.MapPost("/", (HttpRequest request) => Results.Stream(request.Body));

            application.Run(async (context) => await context.Response.SendFileAsync("htmlcss/RootPage/root.html"));

            //application.Map("/Forum1",HandleForum);   

            application.Run();
        }

        /// <summary>
        /// Routing Mapp
        /// </summary>
        /// <param name="applicationBuilder"></param>
        static void HandleForum(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                await context.Response.SendFileAsync("htmlcss/forum.html");
            });
        }
        static void HandleAuthorization(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                await context.Response.SendFileAsync("htmlcss/authorizationuser.html");
            });
        }
        static void HandleRegistration(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                await context.Response.SendFileAsync("htmlcss/registrationuser.html");
            });
        }
        static void HandleRoot(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async context =>
            {
                await context.Response.SendFileAsync("htmlcss/root.html");
            });
        }

    }
}