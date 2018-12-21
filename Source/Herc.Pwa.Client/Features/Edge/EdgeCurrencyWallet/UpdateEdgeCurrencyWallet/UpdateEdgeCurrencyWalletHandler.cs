
namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.GetEdgeCurrencyWallet
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Features.Edge.State;
  using MediatR;

  public class UpdateEdgeCurrencyWalletHandler : BaseHandler<UpdateEdgeCurrencyWalletAction, EdgeCurrencyWalletsState>
  {
    public UpdateEdgeCurrencyWalletHandler(
      IStore aStore,
      IMediator aMediator,
      Subscriptions aSubscriptions) : base(aStore)
    {
      Mediator = aMediator;
      Subscriptions = aSubscriptions;
    }

    private IMediator Mediator { get; }
    private Subscriptions Subscriptions { get; }

    public override async Task<EdgeCurrencyWalletsState> Handle(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeCurrencyWalletAction);
      Subscriptions.ReRenderSubscribers<EdgeCurrencyWalletsState>();

      return await Task.FromResult(EdgeCurrencyWalletsState);
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
      edgeCurrencyWallet.EdgeTransactions = MapEdgeTransactions(aUpdateEdgeCurrencyWalletAction);
    }

    private List<EdgeTransaction> MapEdgeTransactions(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction)
    {
      var edgeTransactions = new List<EdgeTransaction>();
      aUpdateEdgeCurrencyWalletAction.EdgeTransactions.ForEach(
        (aEdgeTransaction) =>
        {
          var edgeTransaction = new EdgeTransaction
          {
            CurrencyCode = aEdgeTransaction.CurrencyCode,
            BlockHeight = aEdgeTransaction.BlockHeight,
            Date = aEdgeTransaction.Date,
            NativeAmount = aEdgeTransaction.NativeAmount,
            NetworkFee = aEdgeTransaction.NetworkFee,
            OurReceiveAddresses = aEdgeTransaction.OurReceiveAddresses,
            ParentNetworkFee = aEdgeTransaction.ParentNetworkFee,
            SignedTx = aEdgeTransaction.SignedTx
          };
        });

      return edgeTransactions;

    }

  }
}
