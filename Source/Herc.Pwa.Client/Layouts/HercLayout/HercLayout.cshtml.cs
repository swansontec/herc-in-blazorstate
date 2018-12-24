namespace Herc.Pwa.Client.Layouts.HercLayout
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Pages.Edge;
  using Microsoft.AspNetCore.Blazor;
  using Microsoft.AspNetCore.Blazor.Components;

  public class HercLayoutModel : BaseComponent, IComponent
  {

    [Parameter] protected RenderFragment Body { get; set; }

    protected override async Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route to Edge to Login
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
      }
    }
  }
}
