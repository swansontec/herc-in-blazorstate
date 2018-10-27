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
    public class GetWalletHandler : BaseHandler<GetWalletAction, EdgeState>
    {
      public GetWalletHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<EdgeState> Handle(GetWalletAction aGetWalletAction, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"onLoginRequest.UserName:{aGetWalletAction.Type}");
        string result = await JSRuntime.Current.InvokeAsync<string>("EdgeInterop.GetFirstWalletInfo");
        Console.WriteLine($"{result}");

        return EdgeState;
      }
    }
  }
}