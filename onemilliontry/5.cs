// namespace Middleware.Example;
// public interface IMessageWriter
// {
//     void Write(string message);
// }
// public class LoggingMessageWriter : IMessageWriter
// {
//     private readonly ILogger<LoggingMessageWriter> _logger;

//     public LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) =>
//         _logger = logger;

//     public void Write(string message) =>
//         _logger.LogInformation(message);
// }
using Azure.Core;
using Microsoft.Net.Http.Headers;

namespace HttpContextInBackgroundThread;

public class UserAgentHeaderHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger _logger;
    public UserAgentHeaderHandler(IHttpContextAccessor httpContextAccessor,
            ILogger<UserAgentHeaderHandler> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage>
    SendAsync(HttpRequestMessage request,
    CancellationToken cancellationToken)
    {
        var contextRequest = _httpContextAccessor.HttpContext?.Request;
        string? userAgentString = contextRequest?.Headers["user-agent"].ToString();
        if (string.IsNullOrEmpty(userAgentString))
        {
            userAgentString = "Unknown";
        }
        request.Headers.Add(HeaderNames.UserAgent, userAgentString);
        _logger.LogInformation($"User-Agent:{userAgentString}");
        return await base.SendAsync(request, cancellationToken);
    }
}


// namespace HttpContextInBackgroundThread;
// public class PereodicBranchesLoggerService : BackgroundService
// {
//     private readonly IHttpClientFactory _httpClientFactory;
//     private readonly ILogger _logger;
//     private readonly PeriodicTimer _timer;

//     public PeriodicBranchesLoggerService(IHttpClientFactory httpClientFactory,
//                         ILogger<PeriodicBranchesLoggerSerive> logger)
//     {
//         _httpClientFactory = httpClientFactory;
//         _logger = logger;
//         _timer = new PeriodicTimer(TimeSpan.FromSeconds(30));
//     }

//     protected override async Task ExecuteAsync(CancellationToken stoppingToke)
//     {
//         while (await _timer.WaitForNextTickAsync(stoppingToken))
//         {
//             try
//             {
//                 if (HttpResponseMessage.IsSuccessStatusCode)
//                 {
//                     using var contentStream = await HttpResponseMessage.Content.ReadAsStreamAsync(stoppingToken);
//                     var response = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(contentStream, cancellationToken: stoppingToken);

//                     _logger.LogInformation($"Branch sync failed! http status code:{httpResponseMEssage.StatusCode}");
//                 }
//                 else
//                 {
//                     _logger,LogError(1, $"Branch sync failed! HTTP status code: {httpResponseMessage.StatusCode}");
//                 }
//             }
//             catch (Exception exception)
//             {
//                 _logger.LogError(1, exception, "Branch sync failed!");
//             }
//         }
//     }
//     public override Task StopAsync(CancellationToken cancellationToken)
//     {
//         _timer.Dispose();
//         return base.StopAsync(cancellationToken);
//     }
// }
