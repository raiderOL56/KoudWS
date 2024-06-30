using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace KoudWS.Services
{
    public class CustomSwaggerService : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public CustomSwaggerService(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateApiInfo(description));
        }

        private OpenApiInfo CreateApiInfo(ApiVersionDescription description)
        {
            OpenApiInfo openApiInfo = new OpenApiInfo()
            {
                Title = "Koud Tv Shows",
                Version = description.ApiVersion.ToString(),
                Description = "Webservice de Tv Shows!",
                Contact = new OpenApiContact()
                {
                    Email = "erick_h98@outlook.com",
                    Name = "Erick Hernández"
                }
            };

            if (description.IsDeprecated)
                openApiInfo.Description += " | This API has been deprecated";

            return openApiInfo;
        }
    }
}