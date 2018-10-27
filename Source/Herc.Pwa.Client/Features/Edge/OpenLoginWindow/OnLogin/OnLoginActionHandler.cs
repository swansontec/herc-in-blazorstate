namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Pages.Login;
  using MediatR;

  public partial class EdgeState
  {
    public class OnLoginActionHandler : BaseHandler<OnLoginAction, EdgeState>
    {
      public OnLoginActionHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<EdgeState> Handle(OnLoginAction aOnLoginRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"onLoginRequest.UserName:{aOnLoginRequest.UserName}");
        EdgeState.UserName = aOnLoginRequest.UserName;
        EdgeState.IsLoggedIn = true;
        Console.WriteLine($"Redirecting back to Login");
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginModel.Route });
        Console.WriteLine($"Redirected to Login");
        return EdgeState;
      }
    }
  }
}