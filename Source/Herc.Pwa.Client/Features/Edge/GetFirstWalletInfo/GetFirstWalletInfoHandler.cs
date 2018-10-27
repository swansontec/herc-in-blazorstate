namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using MediatR;
  using Microsoft.JSInterop;

  public partial class EdgeState
  {
    public class GetFirstWalletInfoHandler : BaseHandler<GetFirstWalletInfoAction, EdgeState>
    {
      public GetFirstWalletInfoHandler(IStore aStore, IMediator aMediator) : base(aStore)
      {
        Mediator = aMediator;
      }

      private IMediator Mediator { get; }

      public override async Task<EdgeState> Handle(GetFirstWalletInfoAction aGetWalletAction, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"onLoginRequest.UserName:{aGetWalletAction.Type}");
        string result = await JSRuntime.Current.InvokeAsync<string>("EdgeInterop.GetFirstWalletInfo", aGetWalletAction.Type);
        Console.WriteLine($"GetFirstWalletInfo result: {result}");

        return EdgeState;
      }
    }
  }
}