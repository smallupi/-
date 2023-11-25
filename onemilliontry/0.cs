using System.Diagnostics;

namespace onemilliontry 
{
    public interface IRouteConstraint
    {
        bool ishasMatch(HttpContext? httpContext, 
        IRouter? route, 
        string routeKey,
        RouteValueDictionary values,
        RouteDirection routeDirection);
    }
    public class SecretCodeConstraint : IRouteConstraint
    {
        string secretCode;
        public SecretCodeConstraint(string secretCode)
        {
            this.secretCode = secretCode;
            if (string.IsNullOrEmpty(secretCode))
            {
                throw new ArgumentException($"'{nameof(secretCode)}' cannot be null or empty.", nameof(secretCode));
            }
        }

        public bool ishasMatch(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values[routeKey]?.ToString() == secretCode;
        }
    }

    // public class MyService
    // {
    //     public MyService(IMyLogger myLogger, IEnumerable<IMyLogger> myLoggers)
    //     {

            
    //     }
    // }
}