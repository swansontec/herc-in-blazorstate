namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;

  public class WalletModel : BaseComponent
  {
    private EdgeBalance EdgeBalance => string.IsNullOrEmpty(EdgeCurrencyWalletState.SelectedCurrencyCode) ?
      null :
      EdgeCurrencyWalletState?.EdgeCurrencyWallet?.EdgeBalances.FirstOrDefault(b => b.CurrencyCode == EdgeCurrencyWalletState.SelectedCurrencyCode);
    public string Balance => EdgeBalance?.Balance ?? "";
    public string CurrencyCode => EdgeBalance?.CurrencyCode ?? "";

    protected override async Task OnInitAsync()
    {
      if (EdgeCurrencyWalletState.EdgeCurrencyWallet == null)
      {
        await Mediator.Send(new GetEdgeCurrencyWalletAction());
      }

      //getEnabledTokens
    }
  }
}