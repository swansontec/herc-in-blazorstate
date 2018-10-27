namespace HercPwa2.Client.Pages.Home
{
  using HercPwa2.Client.Components;
  using HercPwa2.Client.Pages.Login;

  public class HomeModel : BaseComponent
  {
    public const string Route = "Home";

    protected override void OnInit()
    {
      // Are we in the proper state for this page?
      if (!EdgeState.IsLoggedIn)
      {
        Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginModel.Route });
      }

      base.OnInit();
    }

  }
}
