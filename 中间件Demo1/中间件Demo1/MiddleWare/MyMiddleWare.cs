using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 中间件Demo1.MiddleWare
{
    public class MyMiddleWare
    {
        private readonly RequestDelegate _next;

        public MyMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //获取当前请求的全地址，这个GetAbsoluteUri方法是需要自己实现的，暂时没找到core现成获取的
            string str = HttpRequestExtensions.GetAbsoluteUri(context.Request);
            //下面这个if这里就是写 逻辑的，比如读取cookies判断用户有没有登录，这里就不写了 只是简单做个例子
            if (!str.Contains("/Home/About"))//如果地址不包含/Home/About 则跳转
            {
                context.Response.Redirect("/Home/About");
            }
            
            await _next(context);
        }
    }
}
