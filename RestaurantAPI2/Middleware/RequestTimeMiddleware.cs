using System.Diagnostics;

namespace RestaurantAPI2.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware( ILogger<RequestTimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var miliseconds = _stopwatch.ElapsedMilliseconds;
            if(miliseconds / 1000 > 4)
            {
                var message = $"Request {context.Request.Method} at {context.Request.Path} elapsed {miliseconds}ms";
                _logger.LogInformation(message);
            }
        }
    }
}
