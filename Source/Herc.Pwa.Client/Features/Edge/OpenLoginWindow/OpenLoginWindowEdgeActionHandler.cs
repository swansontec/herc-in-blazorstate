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
    public class OpenLoginWindowEdgeActionHandler : BaseHandler<OpenLoginWindowEdgeAction, EdgeState>
    {
      public OpenLoginWindowEdgeActionHandler(IStore aStore) : base(aStore) { }

      public override async Task<EdgeState> Handle(OpenLoginWindowEdgeAction openLoginWindowEdgeRequest, CancellationToken cancellationToken)
      {
        await JSRuntime.Current.InvokeAsync<bool>("EdgeInterop.OpenLoginWindow");
        return EdgeState;
      }
    }
  }
}