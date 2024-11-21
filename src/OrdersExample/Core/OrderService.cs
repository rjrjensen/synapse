using System.Text.Json;

namespace OrdersExample.Core;

public class OrderService(IHttpClientFactory httpClientFactory, ILogger<OrderService> logger)
{
    public async Task<object[]> GetOrders()
    {
        var client = httpClientFactory.CreateClient(HttpOptions.OrdersApi);

        var response = await client.GetAsync("orders");

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("Failed to get orders");

            return [];
        }

        using var content = await response.Content.ReadAsStreamAsync();

        var orders = await JsonSerializer.DeserializeAsync<object[]>(content);

        return orders;
    }
}