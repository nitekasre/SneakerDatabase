using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
namespace Assignment12_1.Filters
{
    public class SImpleActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action is executed" + context.Controller.ToString());
        }
    }
}
