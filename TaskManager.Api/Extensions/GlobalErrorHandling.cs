using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Extensions;

public static class GlobalErrorHandling
{
    public static void HandleErrors(this WebApplication app)
    {
        app.UseExceptionHandler(applicationBuilder =>
        {
            applicationBuilder.Run(async context =>
            {
                var requestError = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                if (requestError is not null)
                {
                    var details = new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Type = context.Response.ContentType,
                        Title = "Internal Server Error",
                        Detail =
                            $"{requestError.Message}\n{requestError.StackTrace}\n{requestError.InnerException?.Message}",
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(details));
                }
            });
        });
    }
}