using StackExchange.Redis;

namespace MultiShopProject.Basket.Settings;

public class RedisService
{
    public string _host { get; set; }
    public int _port { get; set; }
    private ConnectionMultiplexer _connectionMultiplexer; //constructor içerisine dahil edilmedi.
    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
    public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0); // int db = 1 ataması redisin sıralı db önergesinden seçilen 1 numaralı db ve 0.Database'i getir.

}
