namespace HercPwa2.Client.Pages.Login
{
  using HercPwa2.Client.Components;

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
          //Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route});
        } else
        {
          // Route them to Idology Page
          //Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route});
        }
      } 
      base.OnInit();
    }
  }
}
