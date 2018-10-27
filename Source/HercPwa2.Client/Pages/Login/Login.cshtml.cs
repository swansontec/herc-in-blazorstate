namespace HercPwa2.Client.Pages.Login
{
  using HercPwa2.Client.Components;
  using HercPwa2.Client.Features.Edge;
  using HercPwa2.Client.Pages.Home;
  using HercPwa2.Client.Pages.Idology;

  public class LoginModel : BaseComponent
  {
    public const string Route = "Login";

    protected override void OnInit()
    {
      // Are we in the proper state for this page?
      if (EdgeState.IsLoggedIn) 
      {
        if (IdologyState.IsValid)
        {
          // Route them to Home Page
          Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route});
        } else
        {
          // Route them to Idology Page
          Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route});
        }
      } else
      {
        Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgeModel.Route });
      }


      base.OnInit();
    }
  }
}
