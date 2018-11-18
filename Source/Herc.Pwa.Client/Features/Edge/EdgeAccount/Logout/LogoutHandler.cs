namespace Herc.Pwa.Client.Features.Edge.EdgeAccount
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Microsoft.JSInterop;

  public partial class EdgeAccountState
  {
    public class LougoutHandler : BaseHandler<LogoutAction, EdgeAccountState>
    {
      public LougoutHandler(IStore aStore) : base(aStore) { }

      public override async Task<EdgeAccountState> Handle(LogoutAction aShowLoginWindowEdgeRequest, CancellationToken aCancellationToken)
      {
        await JSRuntime.Current.InvokeAsync<bool>(EdgeInteropMethodNames.EdgeAccountInterop_Logout);
        return EdgeAccountState;
      }
    }
  }
}