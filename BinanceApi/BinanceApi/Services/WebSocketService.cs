using System;
using WebSocketSharp;
using Newtonsoft.Json.Linq;

namespace BinanceApi
{
    public class WebSocketService
    {
        public void Startup(string crypto)
        {
            using (WebSocket ws = new WebSocket($"wss://stream.binance.com:9443/ws/{crypto}@trade"))
            {
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();
                Console.ReadKey();
            }
        }

        public static void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            JObject json = JObject.Parse(e.Data);
            var price = json.SelectToken("p").ToObject<decimal>();
            using (var db = new BinanceDbContext())
            {
                var crypto = new Crypto(price);
                db.Crypto.Add(crypto);
                db.SaveChanges();
                Console.WriteLine(price);
            }
        }
    }
}
