namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Blazor.Components;

  public class EdgeTransactionComponentModel : BaseComponent
  {

    [Parameter] protected EdgeTransaction EdgeTransaction { get; set; }


  }
}