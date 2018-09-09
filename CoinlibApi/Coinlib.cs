using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinlibApi.Types.Response;
using Newtonsoft.Json;
using Coinlist = CoinlibApi.Types.Response.Coinlist;
using CoinlistOrder = CoinlibApi.Types.Enums.CoinlistOrder;
using Coins = CoinlibApi.Types.Response.Coins;
using Global = CoinlibApi.Types.Response.Global;

namespace CoinlibApi
{
	public class Coinlib
	{
		public Coinlib(string apikey)
		{
			this.apikey = apikey;
		}

		private readonly string apikey;

		private const string baseurl = "https://coinlib.io/api/v1";

        /// <summary>
        /// Global market stats
        /// </summary>
        /// <param name="pref">symbol to use for prices and other market values. Default is USD.</param>
        /// <returns></returns>
		public async Task<Global> Global(string pref = "USD")
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/global?key={apikey}&pref={pref}");
		    }

		    return JsonConvert.DeserializeObject<Global>(response);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page">starting from 1. For now return 100 results per page, but this may change without warning.</param>
        /// <param name="pref">symbol to use for prices and other market values. Default is USD.</param>
        /// <param name="order">For rank (first to last) use rank_asc
        /// For rank (last to first) use rank_desc
        /// For volume 24h (low to high) use volume_asc
        /// For volume 24h (high to low) use volume_desc
        /// For price (low to high) use price_asc
        /// For price (high to low) use price_desc
        /// For date listed (recent to older) use date_inserted_asc
        /// For date listed (older to recent) use date_inserted_desc</param>
        /// <returns></returns>
		public async Task<Coinlist> Coinlist(int page = 1, string pref = "USD", CoinlistOrder order = CoinlistOrder.rank_asc)
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/coinlist?key={apikey}&pref={pref}&page={page}&order={order.ToString()}");
		    }

		    return JsonConvert.DeserializeObject<Coinlist>(response);
		}

        /// <summary>
        /// Coin info
        /// You can get info for up to 10 coins with a single call. Give a comma separated list of symbols
        /// </summary>
        /// <param name="symbol">single coin symbol or a comma separated list of symbols</param>
        /// <param name="pref">symbol to use for prices and other market values. Default is USD.</param>
        /// <returns></returns>
		public async Task<CoinsCoin> Coin(string symbol, string pref = "USD")
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/coin?key={apikey}&pref={pref}&symbol={symbol}");
		    }

		    return JsonConvert.DeserializeObject<CoinsCoin>(response);
		}

        /// <summary>
        /// List of coins info
        /// You can get info for up to 10 coins with a single call. Give a list of symbols
        /// Using more coins calling api more times!!
        /// </summary>
        /// <param name="symbols">List of coins symbols</param>
        /// <param name="pref">symbol to use for prices and other market values. Default is USD.</param>
        /// <returns></returns>
		public async Task<Coins> Coins(List<string> symbols, string pref = "USD")
		{
            var result = new Coins(){CoinsList=new List<CoinsCoin>()};
		    for (int i = 0; i < symbols.Count; i+=10)
		    {
		        var list = symbols.GetRange(i, Math.Min(10, symbols.Count - i));
		        using (var http = new HttpClient())
		        {
		            var response = await http.GetStringAsync($"{baseurl}/coin?key={apikey}&pref={pref}&symbol={string.Join(",", list)}");
		            var coins = JsonConvert.DeserializeObject<Coins>(response);
                    result.CoinsList.AddRange(coins.CoinsList);
		            result.Remaining = coins.Remaining;
		        }
            }
		    
            return result;
		}
	}
}
