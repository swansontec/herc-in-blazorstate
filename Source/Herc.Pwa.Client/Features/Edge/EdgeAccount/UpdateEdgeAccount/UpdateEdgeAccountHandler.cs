namespace Herc.Pwa.Client.Features.Edge.EdgeAccount
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using MediatR;

  public class UpdateEdgeAccountHandler : BaseHandler<UpdateEdgeAccountAction, EdgeAccountState>
  {
    public UpdateEdgeAccountHandler(
      IStore aStore, 
      IMediator aMediator,
      Subscriptions aSubscriptions) : base(aStore)
    {
      Mediator = aMediator;
      Subscriptions = aSubscriptions;
    }

    private IMediator Mediator { get; }
    private Subscriptions Subscriptions { get; }

    public override async Task<EdgeAccountState> Handle(UpdateEdgeAccountAction aUpdateEdgeAccountAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeAccountAction);
      Subscriptions.ReRenderSubscribers<EdgeAccountState>();
      return await Task.FromResult(EdgeAccountState);
    }

    private void MapActionToState(UpdateEdgeAccountAction aUpdateEdgeAccountAction)
    {
      EdgeAccountState.Id = aUpdateEdgeAccountAction.Id;
      EdgeAccountState.LoggedIn = aUpdateEdgeAccountAction.LoggedIn;
      EdgeAccountState.Username = aUpdateEdgeAccountAction.Username;
    }
  }
}
