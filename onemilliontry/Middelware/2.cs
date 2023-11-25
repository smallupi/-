// using System.Runtime.CompilerServices;

// namespace Middleware.Example;

// public class MyCustomMiddleware
// {
//     private readonly RequestDelegate _next;

//     public MyCustomMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }
//     public async Task InvokeAsync(HttpContext httpContext, IMessageWriter  svc)
//     {
//         svc.Write(DateTime.Now.Ticks.ToString());
//         await _next(httpContext);
//     }
// }

// public static class MyCustomMiddlewareExtentions
// {
//     public static IApplicationBuilder UseMyCustomMiddleware(
//         this IApplicationBuilder builder)
//     {
//         return builder.UseMiddleware<MyCustomMiddleware>();
//     }
// }

// using Microsoft.Data.SqlClient;
// using Microsoft.Extensions.Logging;

// namespace onemilliontry
// {

    // public class Logger{
    //     public static void logger(string[] args)
    //     {
    //         var loggerFactory = LoggerFactory.Create(create =>
    //         {
    //             create.ClearProviders();
    //             create.AddDebug();
    //             create.AddConsole();
    //             //create.AddEventLog();
    //             create.AddFilter("System", LogLevel.Debug)
    //                 .SetMinimumLevel(LogLevel.Debug);
    //             // .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
    //         });
    //         ILogger logger = loggerFactory.CreateLogger("WebApplication");
    //     }
    // }
    
//     public class SqlConnection{
//         public static void SqlConnectionStringBuilder(string[] args){
//             SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

//             var loggerFactory = LoggerFactory.Create(create =>
//             {
//                 create.ClearProviders();
//                 create.AddDebug();
//                 create.AddConsole();
//                 //create.AddEventLog();
//                 create.AddFilter("System", LogLevel.Debug)
//                     .SetMinimumLevel(LogLevel.Debug);
//                 // .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
//             });
//             ILogger logger = loggerFactory.CreateLogger("WebApplication");
            
//             using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
//             {
//                 logger.LogInformation($"SqlConnection is open !");
//                 string sql = "SELECT onemilliontry, Users FROM onemilliontry";
//                 using (SqlCommand command = new SqlCommand(sql, connection))
//                 {
//                     connection.Open();
//                     using(SqlDataReader reader = command.ExecuteReader())
//                     {
//                         while(reader.Read())
//                         {
//                             logger.LogInformation("{0} {1}", reader.GetString(0), reader.GetString(1));

//                         }
//                     }
//                 }
//             }
//         }
//     }
// }


// SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            // connectionString = "Data Source=LIGHT\\SQLEXPRESS01;Initial Catalog=onemilliontry;Integrated Security=True;TrusServerCertificate=True;";
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
