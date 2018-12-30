namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Blazor.Components;
  using Herc.Pwa.Client.Services;

  public class EdgeTransactionComponentModel : BaseComponent
  {

    [Parameter] protected EdgeTransaction EdgeTransaction { get; set; }
    public string SendOrReceive(string aTransValueAmount) => aTransValueAmount.Substring(0,1) == "-" ? "Sent" : "Received";

    [Inject] public AmountConverter AmountConverter { get; set; }
    private int Granularity => 18; // multiplier is 10^18 18 places 
    [Parameter] protected int DecimalPlacesToDisplay { get; set; } = 6;
    public string DisplayBalance
    {
      get
      {
        var balanceFormaterRequest = new FormatAmountRequest()
        {
          Amount = EdgeTransaction.NativeAmount,
          Granularity = Granularity,
          DecimalPlacesToDisplay = DecimalPlacesToDisplay,
        };
        return AmountConverter.GetFormatedAmount(balanceFormaterRequest);
      }
    }

  }
}

