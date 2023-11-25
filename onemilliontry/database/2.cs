// using Microsoft.Extensions.Options;

// namespace onemilliontry
// {
//     class GETUser
//     {
//         RequestDelegate next;
//         private protected User User {get;}

//         public GETUser(RequestDelegate next,IOptions<User> options)
//         {
//             this.next = next;
//             User = options.Value;
            
//         }
//         public async Task InvokeAsync(HttpContext context)
//         {
//             System.Text.StringBuilder stringBuilder = new();
//             if(context.Request.Path == "/registration/api") return;
//             //response to database
//             //await context.Response.WriteAsJsonAsync();
//             else await next.Invoke(context);
//         }
//     }
// }