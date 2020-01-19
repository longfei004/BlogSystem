using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BlogSystem.Portal.ExceptionHandleMiddleWare
{
    public class ExceptionHandle
    {
        private RequestDelegate _next;

        private IDictionary<int, string> exceptionStatusCodeDic;

        public ExceptionHandle(RequestDelegate next)
        {
            _next = next;
            exceptionStatusCodeDic = new Dictionary<int, string>
            { 
                { 400, "请求信息错误" },
                { 404, "找不到该页面" },
                { 405, "不允许该请求" },
                { 403, "访问被拒绝" },
                { 500, "服务器发生意外的错误" }
            };
        }

        public async Task Invoke(HttpContext context)
        {
            Exception exception = null;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 500;
                exception = ex;
            }
            finally
            {
                if (exceptionStatusCodeDic.ContainsKey(context.Response.StatusCode)
                    && !context.Items.ContainsKey("ExceptionHandled"))
                {
                    var errorMsg = string.Empty;
                    if (context.Response.StatusCode == 500 && exception != null)
                    {
                        errorMsg = $"{exceptionStatusCodeDic[context.Response.StatusCode]} / "
                            + $"{(exception.InnerException != null ? exception.InnerException.Message : exception.Message)}";
                    }
                    else
                    {
                        errorMsg = exceptionStatusCodeDic[context.Response.StatusCode];
                    }
                    exception = new Exception(errorMsg);
                }

                if (exception != null)
                {
                    var apiRespose = new { IsSuccess = false, Message = exception.Message };
                    var responseStr = JsonConvert.SerializeObject(apiRespose);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(responseStr, Encoding.UTF8);
                }
            }
        }
    }
}