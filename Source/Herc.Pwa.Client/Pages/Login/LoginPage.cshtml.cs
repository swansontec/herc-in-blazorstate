namespace Herc.Pwa.Client.Pages.Login
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Pages.Edge;

  public class LoginPageModel : BaseComponent
  {
    public const string Route = "Login";

    protected override async Task OnInitAsync() => 
      await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
  }
}
