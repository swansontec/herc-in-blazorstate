namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Clipboard;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.Send;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Shared;
  using Herc.Pwa.Shared.Enumerations.FeeOption;
  using Microsoft.AspNetCore.Blazor.Components;
  using Microsoft.JSInterop;

  public class WalletReceivePageModel : BaseComponent
  {
    [Inject] public AmountConverter AmountConverter { get; set; }
    public static string Route(string aEdgeCurrencyWalletEncodedId) => $"/wallet/{aEdgeCurrencyWalletEncodedId}/Receive";

    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }

    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    private EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];

    public string ReceiveAddress => EdgeCurrencyWallet.Keys["ethereumAddress"];

    protected async Task CopyToClipboardAsync() => 
      await JSRuntime.Current.InvokeAsync<object>(ClipboardInteropMethodNames.ClipboardInterop_WriteText, ReceiveAddress);

  }
}
