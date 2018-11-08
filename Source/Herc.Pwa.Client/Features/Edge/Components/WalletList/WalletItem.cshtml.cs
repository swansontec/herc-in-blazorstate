namespace Herc.Pwa.Client.Features.Edge.Components.WalletList
{
  using Microsoft.AspNetCore.Blazor.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Components;
  using System.Net;

  public class WalletItemModel: BaseComponent
  {

    public string EdgeCurrencyWalletId => EdgeCurrencyWallet.Id;

    [Parameter]
    protected EdgeCurrencyWallet EdgeCurrencyWallet { get; set; }

    public string Route => $"wallet/{WebUtility.UrlEncode(EdgeCurrencyWalletId)}";
  }
}
