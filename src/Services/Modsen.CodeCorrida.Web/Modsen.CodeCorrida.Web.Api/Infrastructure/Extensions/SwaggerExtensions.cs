using System.Reflection;
using Modsen.CodeCorrida.Web.Api.Infrastructure.Swagger;
using Microsoft.OpenApi.Models;

namespace Modsen.CodeCorrida.Web.Api.Infrastructure.Extensions;

public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                option.IncludeXmlComments(xmlCommentsFullPath);

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                    },
                    new string[]{}
                    }
                });
                
                option.OperationFilter<MergeJsonContentTypeFilter>();
            });
            
            return services;
        }
    }
