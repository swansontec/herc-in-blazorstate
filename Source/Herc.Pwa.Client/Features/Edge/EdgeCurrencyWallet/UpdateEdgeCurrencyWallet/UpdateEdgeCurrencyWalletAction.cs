namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;
  using MediatR;
  public class UpdateEdgeCurrencyWalletAction : IRequest<EdgeCurrencyWalletState>
  {
    public Dictionary<string, string> Balances { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public List<EdgeBalance> EdgeBalances { get; set; }
    public List<string> EnabledTokens { get; set; }
    public string FiatCurrencyCode { get; set; }
    public string Id { get; set; }
  }
}
