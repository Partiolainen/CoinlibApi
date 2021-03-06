﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinlibApi.Types.Response
{
	public class Coins
	{
		[JsonProperty("coins")]
		public List<CoinsCoin> CoinsList { get; set; }

		[JsonProperty("remaining")]
		public int Remaining { get; set; }
	}
	public class CoinsCoin
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
		public double? Price { get; set; }

		[JsonProperty("market_cap")]
		public double? MarketCap { get; set; }

		[JsonProperty("total_volume_24h")]
		public double? TotalVolume24h { get; set; }

		[JsonProperty("low_24h")]
		public double? Low24h { get; set; }

		[JsonProperty("high_24h")]
		public double? High24h { get; set; }

		[JsonProperty("delta_1h")]
		public double? Delta1h { get; set; }

		[JsonProperty("delta_24h")]
		public double? Delta24h { get; set; }

		[JsonProperty("delta_7d")]
		public double? Delta7d { get; set; }

		[JsonProperty("delta_30d")]
		public double? Delta30d { get; set; }

		[JsonProperty("markets")]
		public List<CoinsMarket> Markets { get; set; }

		[JsonProperty("last_updated_timestamp")]
		public int LastUpdatedTimestamp { get; set; }
	}
	public class CoinsMarket
	{
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("volume_24h")]
		public double? Volume24h { get; set; }

		[JsonProperty("price")]
		public double? Price { get; set; }

		[JsonProperty("exchanges")]
		public List<CoinsExchange> Exchanges { get; set; }
	}
	public class CoinsExchange
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("volume_24h")]
		public double? Volume24h { get; set; }

		[JsonProperty("price")]
		public double? Price { get; set; }
	}

}
