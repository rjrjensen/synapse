namespace OrdersExample.Core;

public class UpdateService(IHttpClientFactory httpClientFactory)
{
    public async Task UpdateOrders()
    {
        var client = httpClientFactory.CreateClient(HttpOptions.UpdateApi);

        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}