using Microsoft.AspNetCore.Mvc.Filters;

namespace ECOM.Template.API.Filters
{
    public class FilterTemplateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            InitVariables.RawRequest = string.Empty;

            switch (actionContext.HttpContext.Request.Method)
            {
                case "GET":
                    InitVariables.Parameters = $@"{actionContext.HttpContext.Request.QueryString.Value}";
                    break;
            }

            //VariablesGlobales.Headers = actionContext.Request.Headers;
            InitVariables.Headers = new Dictionary<string, IEnumerable<string>>();

            foreach (var Item in actionContext.HttpContext.Request.Headers)
                InitVariables.Headers.Add(Item.Key, Item.Value);

            /*foreach (var Item in actionContext.HttpContext.Request.Content.Headers)
            {
                InitVariables.Headers.Add(Item.Key, Item.Value);
                if (((string[])Item.Value)[0] == "application/x-www-form-urlencoded")
                {
                    using (var stream = new StreamReader(actionContext.Request.Content.ReadAsStreamAsync().Result))
                    {
                        stream.BaseStream.Position = 0;
                        InitVariables.RawRequest = stream.ReadToEnd();
                    }
                }
            }*/

            InitVariables.PathBase = $@"{actionContext.HttpContext.Request.Path}";
        }
    }
}
