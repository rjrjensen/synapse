namespace OrdersExample.Core;

public class AlertService(IHttpClientFactory httpClientFactory)
{
    public async Task SendAlerts()
    {
        var client = httpClientFactory.CreateClient(HttpOptions.AlertApi);

        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}