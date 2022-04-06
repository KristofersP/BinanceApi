
namespace BinanceApi
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketService ws = new WebSocketService();
            ws.Startup("ethusdt");
        }
    }
}

//btcusdt
//ethusdt
