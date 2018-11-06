
namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.GetEdgeCurrencyWallet
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using MediatR;
  using Microsoft.JSInterop;

  public class UpdateEdgeCurrencyWalletHandler : BaseHandler<UpdateEdgeCurrencyWalletAction, EdgeCurrencyWalletState>
  {
    public UpdateEdgeCurrencyWalletHandler(IStore aStore, IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }

    public override async Task<EdgeCurrencyWalletState> Handle(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction, CancellationToken aCancellationToken)
    {
      MapActionToState(aUpdateEdgeCurrencyWalletAction);

      return EdgeCurrencyWalletState;
    }

    private void MapActionToState(UpdateEdgeCurrencyWalletAction aUpdateEdgeCurrencyWalletAction)
    {

      var edgeBalances = new List<EdgeBalance>();

      aUpdateEdgeCurrencyWalletAction.Balances.ToList().ForEach(aKvp =>
      {
        var edgeBalance = new EdgeBalance()
        {
          Balance = aKvp.Value,
          CurrencyCode = aKvp.Key
        };
        edgeBalances.Add(edgeBalance);
      });

      EdgeCurrencyWalletState.EdgeCurrencyWallet = new EdgeCurrencyWallet
      {
        Id = aUpdateEdgeCurrencyWalletAction.Id,
        FiatCurrencyCode = aUpdateEdgeCurrencyWalletAction.FiatCurrencyCode,
        Keys = aUpdateEdgeCurrencyWalletAction.Keys,
        EdgeBalances = edgeBalances
      };
    }
  }
}
