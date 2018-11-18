namespace Herc.Pwa.Client.Pages.Wallet
{
  using System.Net;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Blazor.Components;

  public class WalletPageModel : BaseComponent
  {
    public const string Route = "wallet/{EdgeCurrencyWalletEncodedId}";

    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    [Parameter]  public string EdgeCurrencyWalletEncodedId { get; set; }
  }
}
