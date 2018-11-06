namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class EdgeCurrencyWallet: ICloneable
  {
    public List<EdgeBalance> EdgeBalances { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public Dictionary<string, string> Balances { get; set; }
    public object Clone()
    {
      var clone = MemberwiseClone() as EdgeCurrencyWallet;
      clone.EdgeBalances = new List<EdgeBalance>(EdgeBalances.Select(aEdgeBalance => aEdgeBalance.Clone() as EdgeBalance));
      clone.Keys = new Dictionary<string, string>(Keys);
      return clone;
    }
  }
}