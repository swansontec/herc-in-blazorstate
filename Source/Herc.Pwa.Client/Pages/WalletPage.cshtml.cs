namespace Herc.Pwa.Client.Pages
{
  using System.Net;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Microsoft.AspNetCore.Blazor.Components;

  public class WalletPageModel : BaseComponent
  {
    public const string Route = "wallet/{EdgeCurrencyWalletEncodedId}";

    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
  }
}