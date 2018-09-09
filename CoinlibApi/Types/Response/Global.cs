using Newtonsoft.Json;

namespace CoinlibApi.Types.Response
{
	public class Global
	{
		[JsonProperty("coins")]
		public int Coins { get; set; }

		[JsonProperty("markets")]
		public int Markets { get; set; }

		[JsonProperty("total_market_cap")]
		public double TotalMarketCap { get; set; }

		[JsonProperty("total_volume_24h")]
		public double TotalVolume24h { get; set; }

		[JsonProperty("last_updated_timestamp")]
		public int LastUpdatedTimestamp { get; set; }

		[JsonProperty("remaining")]
		public int Remaining { get; set; }
	}
}
