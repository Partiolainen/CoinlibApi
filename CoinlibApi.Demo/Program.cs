using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinlibApi.Types;

namespace CoinlibApi.Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var apikey = ""; //Place your api key here
            var client = new CoinlibClient(apikey);

            var globalinfo = await client.Global("BTC");
            Console.WriteLine($"{DateTime.Now:G}\nGlobal market cap: {globalinfo.TotalMarketCap} BTC");
            Console.WriteLine();

            var worstcoin = (await client.Coinlist(1, "BTC", CoinlistOrder.rank_desc)).Coins.FirstOrDefault();
            Console.WriteLine($"{DateTime.Now:G}\n" +
                              $"Worst rank coin: {worstcoin?.Name} with rank #{worstcoin?.Rank}");
            Console.WriteLine();

            var zen = await client.Coin("ZEN", "BTC");
            Console.WriteLine($"{DateTime.Now:G}\nZEN price: {zen.Price} BTC");
            Console.WriteLine();

            var coinslist = new List<string>() {"XEM", "XRP", "TRX"};
            var coins = (await client.Coins(coinslist, "BTC")).Coins;
            var bestoflist = coins.OrderBy(x => x.Rank).FirstOrDefault();
            Console.WriteLine($"{DateTime.Now:G}\nBest rank coin of {string.Join(", ", coinslist)}:" +
                              $" {bestoflist?.Symbol} with rank #{bestoflist?.Rank}");

            Console.ReadKey();
        }
    }
}
