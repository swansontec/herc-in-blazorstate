namespace Herc.Pwa.Client.Features.Edge.Components.Wallet
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Services;
  using Microsoft.AspNetCore.Blazor.Components;

  public class BalanceModel : BaseComponent
  {
    [Parameter]
    protected string Balance { get; set; }

    [Parameter]
    protected string CurrencyCode { get; set; }

    [Inject]
    public BalanceFormater BalanceFormater { get; set; }
    private int Granularity => 18; // multiplier is 10^18 18 places 
    private int DecimalPlacesToDisplay => 18;
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
