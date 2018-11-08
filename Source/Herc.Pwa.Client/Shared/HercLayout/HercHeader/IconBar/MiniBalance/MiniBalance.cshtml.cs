namespace Herc.Pwa.Client.Shared.HercLayout.HercHeader.IconBar.MiniBalance
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Blazor.Components;

  public class MiniBalanceModel : BaseComponent
  {

    [Inject]
    public BalanceFormater BalanceFormater { get; set; }
    private string Balance
    {
      get
      {
        string result = EdgeCurrencyWalletsState.SelectedEdgeCurrencyWallet?.Balances[CurrencyCode];
        if (result == null)
        {
          result = "";
        }
        return result;
      }
    }
    public string CurrencyCode => "HERC";
    private int Granularity => 18; // multiplier is 10^18 18 places 
    private int DecimalPlacesToDisplay => 2;
    public string DisplayBalance
    {
      get
      {
        var balanceFormaterRequest = new BalanceFormaterRequest()
        {
          Balance = Balance,
          Granularity = Granularity,
          DecimalPlacesToDisplay = DecimalPlacesToDisplay,
        };
        return BalanceFormater.GetBalanceDisplay(balanceFormaterRequest);
      }
    }
  }
}
