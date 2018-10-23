namespace HercPwa2.Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using HercPwa2.Client.Features.Base;

  public partial class EdgeState
  {
    public class OnLoginActionHandler : BaseHandler<OnLoginAction, EdgeState>
    {
      public OnLoginActionHandler(IStore aStore) : base(aStore) { }

      public override Task<EdgeState> Handle(OnLoginAction onLoginRequest, CancellationToken cancellationToken)
      {
        Console.WriteLine($"onLoginRequest.UserName:{onLoginRequest.UserName}");
        EdgeState.UserName = onLoginRequest.UserName;
        EdgeState.IsLoggedIn = true;
        return Task.FromResult(EdgeState);
      }
    }
  }
}