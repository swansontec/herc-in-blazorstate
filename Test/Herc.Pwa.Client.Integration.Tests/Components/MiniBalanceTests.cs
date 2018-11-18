using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorState;
using BlazorState.Integration.Tests.Infrastructure;
using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
using Herc.Pwa.Client.Services;
using Herc.Pwa.Client.Shared.HercLayout.HercHeader.IconBar.MiniBalance;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Components
{
  public class MiniBalanceTests
  {
    public MiniBalanceTests(TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      BalanceFormater = ServiceProvider.GetService<AmountConverter>();
      EdgeCurrencyWalletsState = Store.GetState<EdgeCurrencyWalletsState>();
    }

    private EdgeCurrencyWalletsState EdgeCurrencyWalletsState { get; set; }
    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private AmountConverter BalanceFormater { get; }

    public async Task Should_Display_Proper_Decimals()
    {
      var edgeCurrencyWallet = new EdgeCurrencyWallet
      {
        Balances = new Dictionary<string, string>()
        {
          {"HERC","9979261128182853278" }
        }
      };

      EdgeCurrencyWalletsState.EdgeCurrencyWallets["1"] = edgeCurrencyWallet;
      var miniBalanceModel = new MiniBalanceModel()
      {
        BalanceFormater = BalanceFormater,
        Store = Store,
      };

      miniBalanceModel.DisplayBalance.ShouldBe("9.97");
    }
  }
}