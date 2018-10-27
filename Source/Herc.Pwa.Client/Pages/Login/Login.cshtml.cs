namespace Herc.Pwa.Client.Pages.Login
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Pages.Home;
  using Herc.Pwa.Client.Pages.Idology;

  public class LoginModel : BaseComponent
  {
    public const string Route = "Login";


    protected override async Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (EdgeState.IsLoggedIn)
      {
        if (IdologyState.IsValid)
        {
          // Route them to Home Page
          await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route });
        }
        else
        {
          // Route them to Idology Page
          await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route });
        }
      }
      else
      {
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgeModel.Route });
      }
    }

    //protected override void OnInit()
    //{
    //  // Are we in the proper state for this page?
    //  if (EdgeState.IsLoggedIn) 
    //  {
    //    if (IdologyState.IsValid)
    //    {
    //      // Route them to Home Page
    //      Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = HomeModel.Route});
    //    } else
    //    {
    //      // Route them to Idology Page
    //      Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route});
    //    }
    //  } else
    //  {
    //    Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgeModel.Route });
    //  }


    //  base.OnInit();
    //}
  }
}
