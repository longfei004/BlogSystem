using Microsoft.AspNetCore.Builder;

namespace BlogSystem.Portal.ExceptionHandleMiddleWare
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseExceptionHandle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandle>();
        }
    }
}