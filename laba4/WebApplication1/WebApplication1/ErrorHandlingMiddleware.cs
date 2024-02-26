namespace WebApplication1
{
    public class ErrorHandlingMiddleware
    {
        readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
            var sitePath = context.Request.Path;
            if (sitePath == "")
            {
                context.Response.StatusCode = 403;
            }
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Error!");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("Not found!");
            }
        }
    }

}
