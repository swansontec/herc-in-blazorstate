namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using Herc.Pwa.Client.Components;

  public class WalletModel : BaseComponent
  {
    public string Balance { get; set; } = "500";
    public string CurrencyCode { get; set; } = "HERC";
  }
}