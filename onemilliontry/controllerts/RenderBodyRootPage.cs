using Microsoft.AspNetCore.Mvc.RazorPages;

namespace onemilliontry.pages
{
    public class Root:PageModel
    {
        public string RenderMessage {get;private set;} = "PageModel in c#";

        public void OnGet()
        {
            RenderMessage += $"ServerTime is {DateTime.Now}";

        }
    }
}