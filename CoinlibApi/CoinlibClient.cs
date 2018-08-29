using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinlibApi.Types;
using Newtonsoft.Json;

namespace CoinlibApi
{
	public class CoinlibClient
	{
		public CoinlibClient(string apikey)
		{
			this.apikey = apikey;
		}

		private readonly string apikey;

		private const string baseurl = "https://coinlib.io/api/v1";

		public async Task<GlobalResponse> Global(string pref = "USD")
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/global?key={apikey}&pref={pref}");
		    }

		    return JsonConvert.DeserializeObject<GlobalResponse>(response);
		}

		public async Task<CoinlistResponse> Coinlist(int page = 1, string pref = "USD", CoinlistOrder order = CoinlistOrder.rank_asc)
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/coinlist?key={apikey}&pref={pref}&page={page}&order={order.ToString()}");
		    }

		    return JsonConvert.DeserializeObject<CoinlistResponse>(response);
		}

		public async Task<CoinsResponseCoin> Coin(string symbol, string pref = "USD")
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/coin?key={apikey}&pref={pref}&symbol={symbol}");
		    }

		    return JsonConvert.DeserializeObject<CoinsResponseCoin>(response);
		}

		public async Task<CoinsResponse> Coins(List<string> symbols, string pref = "USD")
		{
		    string response;
		    using (var http = new HttpClient())
		    {
		        response = await http.GetStringAsync($"{baseurl}/coin?key={apikey}&pref={pref}&symbol={string.Join(",", symbols)}");
		    }

		    return JsonConvert.DeserializeObject<CoinsResponse>(response);
		}
	}
}
