namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Shared;
  using Herc.Pwa.Shared.Enumerations.FeeOption;
  using Microsoft.AspNetCore.Components;
  using BlazorState.Features.Routing;

  public class WalletSendPageModel : BaseComponent
  {
    [Inject] private AmountConverter AmountConverter { get; set; }
    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }

    public string Amount { get; set; }

    public string Balance => string.IsNullOrEmpty(CurrencyCode) ? "" : EdgeCurrencyWallet.Balances[CurrencyCode];

    public string CurrencyCode { get; set; }

    public string DestinationAddress { get; set; }

    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];

    public FeeOption Fee { get; set; } = FeeOption.Standard;

    public string MaxAmount => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 18, DecimalSeperator = '.', Granularity = 18 });

    public string Pattern => RegularExpressions.FloatingPointNumberNoSign('.');

    public string WalletName => EdgeCurrencyWallet.Name;

    protected override void OnInit()
    {
      if (EdgeCurrencyWallet.Balances.Keys.Any())
      {
        CurrencyCode = EdgeCurrencyWallet.Balances.Keys.First();
      }
    }

    protected async Task Send()
    {
      Console.WriteLine("Sending SendAction");

      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = Amount,
        DecimalSeperator = '.',
        Granularity = 18
      };
      string nativeAmount = AmountConverter.GetNativeAmount(getNativeAmountRequest);
      await Mediator.Send(new SendAction
      {
        EdgeCurrencyWalletId = EdgeCurrencyWalletId,
        NativeAmount = nativeAmount,
        DestinationAddress = DestinationAddress,
        CurrencyCode = CurrencyCode,
        Fee = Fee
      });

      await Mediator.Send(new ChangeRouteRequest { NewRoute = WalletPageModel.Route });
    }

    public static string Route(string aEdgeCurrencyWalletEncodedId) => $"/wallet/{aEdgeCurrencyWalletEncodedId}/Send";
  }
}