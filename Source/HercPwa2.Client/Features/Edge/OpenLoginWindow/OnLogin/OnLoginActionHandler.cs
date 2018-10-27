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

      public override Task<EdgeState> Handle(OnLoginAction aOnLoginRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"onLoginRequest.UserName:{aOnLoginRequest.UserName}");
        EdgeState.UserName = aOnLoginRequest.UserName;
        EdgeState.IsLoggedIn = true;
        return Task.FromResult(EdgeState);
      }
    }
  }
}