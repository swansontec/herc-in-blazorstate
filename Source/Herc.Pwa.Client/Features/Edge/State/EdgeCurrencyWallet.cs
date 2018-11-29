namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;

  public class EdgeCurrencyWallet : ICloneable
  {
    public Dictionary<string, string> Balances { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public string Name { get; set; }

    private string _SelectedCurrencyCode;

    public string SelectedCurrencyCode
    {
      get => _SelectedCurrencyCode ?? Balances.Keys.First();
      set => _SelectedCurrencyCode = value;
    }
    public string EncodedId => WebUtility.UrlEncode(Id);
    public object Clone()
    {
      var clone = MemberwiseClone() as EdgeCurrencyWallet;
      clone.Keys = new Dictionary<string, string>(Keys);
      clone.Balances = new Dictionary<string, string>(Balances);
      return clone;
    }
  }
}