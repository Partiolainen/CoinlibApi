using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinlibApi.Types
{
	public class CoinlistResponse
	{
		[JsonProperty("coins")]
		public List<CoinlistResponseCoin> Coins { get; set; }

		[JsonProperty("last_updated_timestamp")]
		public int LastUpdatedTimestamp { get; set; }

		[JsonProperty("remaining")]
		public int Remaining { get; set; }
	}
	public class CoinlistResponseCoin
	{
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("show_symbol")]
		public string ShowSymbol { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("rank")]
		public int Rank { get; set; }

		[JsonProperty("price")]
		public string Price { get; set; }

		[JsonProperty("market_cap")]
		public string MarketCap { get; set; }

		[JsonProperty("volume_24h")]
		public string Volume24h { get; set; }

		[JsonProperty("delta_24h")]
		public string Delta24h { get; set; }
	}

}
