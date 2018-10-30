namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Pages.Login;
  using MediatR;
  using Microsoft.JSInterop;

  public partial class EdgeState
  {
    public class OnLoginActionHandler : BaseHandler<OnLoginAction, EdgeState>
    {
      public OnLoginActionHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<EdgeState> Handle(OnLoginAction aOnLoginRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"OnLoginActionHandler");
        EdgeState.UserName = aOnLoginRequest.UserName;
        EdgeState.IsLoggedIn = true;
        Console.WriteLine($"Redirecting back to Login");
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = LoginModel.Route });

        await FetchEdgeCurrencyWallet();

        return EdgeState;
      }

      private async Task FetchEdgeCurrencyWallet()
      {
        const string EtheriumWalletType = "wallet:ethereum";
        if (EdgeState.EdgeWalletInfo == null)
        {
          string result = await JSRuntime.Current.InvokeAsync<string>("EdgeInterop.GetFirstWalletInfo", EtheriumWalletType);
          Console.WriteLine($"GetFirstWalletInfo:{result}");
          EdgeState.EdgeWalletInfo = Json.Deserialize<EdgeWalletInfo>(result);
          Console.WriteLine($"EdgeState.EdgeWalletInfo:{EdgeState.EdgeWalletInfo}");
        }

        if (EdgeState.EdgeWalletInfo != null)
        {
          string result = await JSRuntime.Current.InvokeAsync<string>("EdgeInterop.WaitForCurrencyWallet", EdgeState.EdgeWalletInfo.Id);
          Console.WriteLine($"WaitForCurrencyWallet:{result}");
          //EdgeState.EdgeCurrencyWallet = Json.Deserialize<EdgeCurrencyWallet>(result);
        }
        else
        {
          Console.WriteLine($"EdgeState.EdgeWalletInfo == null");
          //EdgeCreateCurrencyWalletOptions EdgeCreateCurrencyWalletOptions = new EdgeCreateCurrencyWalletOptions;
          string result = await JSRuntime.Current.InvokeAsync<string>("EdgeInterop.CreateCurrencyWallet", EtheriumWalletType);
          Console.WriteLine($"CreateCurrencyWallet:{result}");
          //EdgeState.EdgeCurrencyWallet = Json.Deserialize<EdgeCurrencyWallet>(result);
        }
      }
    }
  }
}