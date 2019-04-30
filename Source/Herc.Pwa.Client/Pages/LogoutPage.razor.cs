namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;

  public class LogoutPageModel : BaseComponent
  {
    public const string Route = "logout";

    protected override async Task OnAfterRenderAsync()
    {
      await Mediator.Send(new LogoutAction());
      Console.WriteLine("Change the Route to the Home Page.");
      await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteAction { NewRoute = HomeModel.Route });
    }
  }
}