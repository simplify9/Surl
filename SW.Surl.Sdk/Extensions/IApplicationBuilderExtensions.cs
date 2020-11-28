using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SW.PrimitiveTypes;
using SW.Surl.Sdk;

namespace SW.Surl.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        private static void Mapper(IApplicationBuilder builder)
        {
            builder.Use(async (context, func) =>
            {
                // Can safely assume this won't fail due to mapping constraint.
                string path = context.Request.Path.Value;
                string key = path.Split('/')[1];

                SurlClient client = builder.ApplicationServices.GetService<SurlClient>();

                ApiResult<string> fullUrlResult = await client.GetFullUrl(key);

                if (fullUrlResult.Success)
                {
                    context.Response.Redirect(fullUrlResult.Response);
                }
                else
                {
                    context.Response.StatusCode = 404;
                    await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes($"{key} did not match any URLs"));
                    return;
                }
            });
        }

        public static void UseSurl(this IApplicationBuilder builder)
        {
            builder.Map("/l/*", Mapper);
        }
    }
}