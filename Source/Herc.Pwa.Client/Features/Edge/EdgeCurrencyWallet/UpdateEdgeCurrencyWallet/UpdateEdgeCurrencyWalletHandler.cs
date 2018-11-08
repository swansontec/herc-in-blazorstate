
namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.GetEdgeCurrencyWallet
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using MediatR;

  public class UpdateEdgeCurrencyWalletHandler : BaseHandler<UpdateEdgeCurrencyWalletAction, EdgeCurrencyWalletsState>
  {
    public UpdateEdgeCurrencyWalletHandler(IStore aStore, IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }

    public override async Task<EdgeCurrencyWalletsState> Handle(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeCurrencyWalletAction);

      return await Task.Run(() => EdgeCurrencyWalletsState);
    }

    private void MapActionToState(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction)
    {
      if (!EdgeCurrencyWalletsState.EdgeCurrencyWallets.ContainsKey(aUpdateEdgeCurrencyWalletAction.Id))
      {
        EdgeCurrencyWalletsState.EdgeCurrencyWallets[aUpdateEdgeCurrencyWalletAction.Id] = new EdgeCurrencyWallet();
      }
      EdgeCurrencyWallet edgeCurrencyWallet = EdgeCurrencyWalletsState.EdgeCurrencyWallets[aUpdateEdgeCurrencyWalletAction.Id];
      edgeCurrencyWallet.Id = aUpdateEdgeCurrencyWalletAction.Id;
      edgeCurrencyWallet.FiatCurrencyCode = aUpdateEdgeCurrencyWalletAction.FiatCurrencyCode;
      edgeCurrencyWallet.Keys = aUpdateEdgeCurrencyWalletAction.Keys;
      edgeCurrencyWallet.Balances = aUpdateEdgeCurrencyWalletAction.Balances;
      edgeCurrencyWallet.Name = aUpdateEdgeCurrencyWalletAction.Name;
    }
  }
}
