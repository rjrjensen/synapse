namespace OrdersExample.Core;

public class HttpOptions
{
    public const string OrdersApi = "OrdersApi";
    public const string AlertApi = "AlertApi";
    public const string UpdateApi = "UpdateApi";
    
    public required string BaseAddress { get; set; }
}