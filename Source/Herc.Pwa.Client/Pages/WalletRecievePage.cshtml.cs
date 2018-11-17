namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.Send;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Shared;
  using Herc.Pwa.Shared.Enumerations.FeeOption;
  using Microsoft.AspNetCore.Blazor.Components;

  public class WalletReceivePageModel : BaseComponent
  {
    [Inject] public AmountConverter AmountConverter { get; set; }
    public static string Route(string aEdgeCurrencyWalletEncodedId) => $"/wallet/{aEdgeCurrencyWalletEncodedId}/Receive";

    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }

    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    public EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];

    public string DestinationAddress { get; set; }

    public string Amount { get; set; }

    public FeeOption Fee { get; set; } = FeeOption.Standard;

    public string Balance => string.IsNullOrEmpty(CurrencyCode) ? "" : EdgeCurrencyWallet.Balances[CurrencyCode];
    public string MaxAmount => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 18, DecimalSeperator = '.', Granularity = 18 });

    //TODO calculate based off of multiplier.  Create service for all these type things in BalanceFormatter or similar.

    public string Pattern => RegularExpressions.FloatingPointNumberNoSign('.');

    public string CurrencyCode { get; set; }

    protected async Task Send()
    {
      Console.WriteLine("Sending SendAction");

      var getNativeAmountRequest = new GetNativeAmountRequest
      {
        Amount = Amount,
        DecimalSeperator = '.',
        Granularity = 18
      };
      Console.WriteLine($"getNativeAmountRequest.Amount: {getNativeAmountRequest.Amount}");
      Console.WriteLine($"{AmountConverter == null}");
      string nativeAmount = AmountConverter.GetNativeAmount(getNativeAmountRequest);
      Console.WriteLine("WTF");
      Console.WriteLine($"NativeAmount: {nativeAmount}");
      await Mediator.Send(new SendAction
      {
        EdgeCurrencyWalletId = EdgeCurrencyWalletId,
        NativeAmount = nativeAmount,
        DestinationAddress = DestinationAddress,
        CurrencyCode = CurrencyCode,
        Fee = Fee
      });
    }

    protected override void OnInit()
    {
      if (EdgeCurrencyWallet.Balances.Keys.Any())
      {
        CurrencyCode = EdgeCurrencyWallet.Balances.Keys.First();
      }
    }
  }
}
