namespace Herc.Pwa.Client.Pages
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Pages.Edge;
  using Herc.Pwa.Client.Pages.Idology;

  public class HomeModel : BaseComponent
  {
    public const string Route = "/";
    
    protected override async Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route to Edge to Login
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
      }
      else if (!IdologyState.IsValid)
      {
        // Route them to Idology Page to verify
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route });
      }
    }
  }
}