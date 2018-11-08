namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class EdgeCurrencyWalletDto
  {
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public Dictionary<string, string> Balances { get; set; }
  }
}