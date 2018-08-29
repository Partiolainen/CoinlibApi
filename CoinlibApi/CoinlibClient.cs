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
			ApiKey = apikey;
		}

		private readonly string ApiKey;

		private const string baseurl = "https://coinlib.io/api/v1";

		public async Task<GlobalResponse> Global(string pref = "USD")
		{
			var http = new HttpClient();
			var response = await http.GetStringAsync($"{baseurl}/global?key={ApiKey}&pref={pref}");
			return JsonConvert.DeserializeObject<GlobalResponse>(response);
		}

		public async Task<CoinlistResponse> Coinlist(int page = 1, string pref = "USD", CoinlistOrder order = CoinlistOrder.rank_asc)
		{
			var http = new HttpClient();
			var response = await http.GetStringAsync($"{baseurl}/coinlist?key={ApiKey}&pref={pref}&page={page}&order={order.ToString()}");
			return JsonConvert.DeserializeObject<CoinlistResponse>(response);
		}

		public async Task<CoinsResponseCoin> Coin(string symbol, string pref = "USD")
		{
			var http = new HttpClient();
			var response = await http.GetStringAsync($"{baseurl}/coin?key={ApiKey}&pref={pref}&symbol={symbol}");
			return JsonConvert.DeserializeObject<CoinsResponseCoin>(response);
		}

		public async Task<CoinsResponse> Coins(List<string> symbols, string pref = "USD")
		{
			var http = new HttpClient();
			var response = await http.GetStringAsync($"{baseurl}/coin?key={ApiKey}&pref={pref}&symbol={string.Join(",", symbols)}");
			return JsonConvert.DeserializeObject<CoinsResponse>(response);
		}
	}
}
