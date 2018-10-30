namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;

  public class EdgeBalance
  {
    public string Balance { get; set; }
    public string CurrencyCode { get; set; }
  }

  public class EdgeCurrencyWallet
  {
    public List<EdgeBalance> EdgeBalances { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
  }
}