namespace Herc.Pwa.Client.Pages.Idology
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Pages.Home;
  using Herc.Pwa.Client.Pages.Login;

  public class IdologyModel : BaseComponent
  {
    public const string Route = "Idology";

    protected async override Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeState.IsLoggedIn)
      {
        // Route them to Login Page
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginModel.Route });
      }
      else if (IdologyState.IsValid)
      {
        // Route them to Home Page
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route });
      }
    }
  }
}
