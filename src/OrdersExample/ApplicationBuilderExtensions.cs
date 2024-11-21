using Microsoft.Extensions.Options;
using OrdersExample.Core;

internal static class ApplicationBuilderExtensions
{
    internal static void RegisterHttpClients(this WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddOptions<HttpOptions>(HttpOptions.OrdersApi)
            .Bind(webApplicationBuilder.Configuration.GetRequiredSection($"HttpOptions:{HttpOptions.OrdersApi}"))
            .ValidateDataAnnotations();
        webApplicationBuilder.Services.AddOptions<HttpOptions>(HttpOptions.AlertApi)
            .Bind(webApplicationBuilder.Configuration.GetRequiredSection($"HttpOptions:{HttpOptions.AlertApi}"))
            .ValidateDataAnnotations();
        webApplicationBuilder.Services.AddOptions<HttpOptions>(HttpOptions.UpdateApi)
            .Bind(webApplicationBuilder.Configuration.GetRequiredSection($"HttpOptions:{HttpOptions.UpdateApi}"))
            .ValidateDataAnnotations();

        webApplicationBuilder.Services.AddHttpClient(HttpOptions.OrdersApi, (services, httpClient) =>
        {
            var options = services.GetRequiredKeyedService<IOptionsMonitor<HttpOptions>>(HttpOptions.OrdersApi)
                .CurrentValue;
            httpClient.BaseAddress = new Uri(options.BaseAddress);
        });
        webApplicationBuilder.Services.AddHttpClient(HttpOptions.AlertApi, (services, httpClient) =>
        {
            var options = services.GetRequiredKeyedService<IOptionsMonitor<HttpOptions>>(HttpOptions.AlertApi)
                .CurrentValue;
            httpClient.BaseAddress = new Uri(options.BaseAddress);
        });
        webApplicationBuilder.Services.AddHttpClient(HttpOptions.UpdateApi, (services, httpClient) =>
        {
            var options = services.GetRequiredKeyedService<IOptionsMonitor<HttpOptions>>(HttpOptions.UpdateApi)
                .CurrentValue;
            httpClient.BaseAddress = new Uri(options.BaseAddress);
        });
    }
}