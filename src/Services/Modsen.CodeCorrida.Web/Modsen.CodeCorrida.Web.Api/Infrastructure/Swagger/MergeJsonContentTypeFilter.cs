using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Swagger;

public class MergeJsonContentTypeFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Responses == null)
        {
            return;
        }

        foreach (var (_, response) in operation.Responses)
        {
            if (response.Content == null)
            {
                continue;
            }
            
            var content = response.Content;

            if (content.ContainsKey("text/plain")
                && content.ContainsKey("text/json") 
                && content.ContainsKey("application/json"))
            {
                content.Remove("text/plain");
                content.Remove("text/json");
            }
        }
    }
}
