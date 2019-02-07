namespace Herc.Pwa.Client.Pages
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;

  public class IdologyModel : BaseComponent
  {
    public const string Route = "Idology";

    protected override async Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeAccountState.LoggedIn)
      {
        // Route them to Login Page
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginPageModel.Route });
      }
      else if (IdologyState.IsValid)
      {
        // Route them to Home Page
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route });
      }
    }
  }
}
