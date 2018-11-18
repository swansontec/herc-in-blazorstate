namespace Herc.Pwa.Client.Shared.HercLayout.HercHeader.IconBar.MiniBalance
{
    using System.Collections.Generic;
    using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Blazor.Components;

  public class MiniBalanceModel : BaseComponent
  {

    [Inject]
    public AmountConverter BalanceFormater { get; set; }
    private string Balance
    {
      get
      {
        Dictionary<string, string> balances = EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet?.Balances;
        if (balances?.ContainsKey(CurrencyCode) ?? false)
        {
          return balances[CurrencyCode];
        }

        return "";
      }
    }
    public string CurrencyCode => "HERC";
    private int Granularity => 18; // multiplier is 10^18 18 places 
    private int DecimalPlacesToDisplay => 2;
    public string DisplayBalance
    {
      get
      {
        var balanceFormaterRequest = new FormatAmountRequest()
        {
          Amount = Balance,
          Granularity = Granularity,
          DecimalPlacesToDisplay = DecimalPlacesToDisplay,
        };
        return BalanceFormater.GetFormatedAmount(balanceFormaterRequest);
      }
    }
  }
}
