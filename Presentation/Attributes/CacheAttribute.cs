using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServicesAbstraction;
using System.Text;

namespace Presentation.Attributes;

internal class CacheAttribute(int durationInMinutes) : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string cacheKey = CreateCacheKey(context.HttpContext.Request);

        ICacheService cacheService = context.HttpContext.RequestServices.GetService<ICacheService>()!;
        var cacheValue = await cacheService.GetAsync(cacheKey);
        if (cacheValue is not null)
        {
            context.Result = new ContentResult()
            {
                Content = cacheValue,
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
            return;
        }

        var executedContext = await next.Invoke();

        if (executedContext.Result is OkObjectResult result)
        {
            await cacheService.SetAsync(cacheKey, result.Value, TimeSpan.FromMinutes(durationInMinutes));
        }
    }

    private static string CreateCacheKey(HttpRequest request)
    {
        StringBuilder cacheKeyBuilder = new();
        cacheKeyBuilder.Append(request.Path + '?');

        foreach (var item in request.Query.OrderBy(q => q.Key))
        {
            cacheKeyBuilder.Append($"{item.Key}={item.Value}&");
        }
        return cacheKeyBuilder.ToString();
    }
}
