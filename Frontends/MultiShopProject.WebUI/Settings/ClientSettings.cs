namespace MultiShopProject.WebUI.Settings;

public class ClientSettings
{
    public Client MultiShopProjectVisitorClient { get; set; }
    public Client MultiShopProjectManagerClient { get; set; }
    public Client MultiShopProjectAdminClient { get; set; }
}

public class Client
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
