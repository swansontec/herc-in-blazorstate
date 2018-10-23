namespace HercPwa2.Client.Pages.Idology
{
  using HercPwa2.Client.Components;

  public class IdologyModel : BaseComponent
  {
    public const string Route = "Idology";
    protected override void OnInit()
    {
      // Are we in the proper state for this page?
      if (!EdgeState.IsLoggedIn)
      {
        // Route them to Login Page
        //Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginModel.Route});
              }
      if (IdologyState.IsValid)
      {
        // Route them to Home Page
        //Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route});
      }
      base.OnInit();
    }
  }
}
