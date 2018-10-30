namespace Herc.Pwa.Client.Features.Edge
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Microsoft.JSInterop;

  //TODO: this doesn't use any state so maybe doesn't need BaseHandler
  public partial class EdgeState
  {
    public class ShowLoginWindowEdgeActionHandler : BaseHandler<ShowLoginWindowEdgeAction, EdgeState>
    {
      public ShowLoginWindowEdgeActionHandler(IStore aStore) : base(aStore) { }

      public override async Task<EdgeState> Handle(ShowLoginWindowEdgeAction showLoginWindowEdgeRequest, CancellationToken cancellationToken)
      {
        await JSRuntime.Current.InvokeAsync<bool>("EdgeInterop.ShowLoginWindow");
        return EdgeState;
      }
    }
  }
}