namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Blazor.Components;
  using Herc.Pwa.Client.Services;

  public class EdgeTransactionComponentModel : BaseComponent
  {

    [Parameter] protected EdgeTransaction EdgeTransaction { get; set; }
    [Parameter] protected int DecimalPlacesToDisplay { get; set; } = 6;
    public string SendOrReceive(string aTransValueAmount) => aTransValueAmount.Substring(0,1) == "-" ? "Sent" : "Received";
    private int Granularity { get; set; } = 18; // multiplier is 10^18 18 places 

    [Inject] public AmountConverter AmountConverter { get; set; }
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

