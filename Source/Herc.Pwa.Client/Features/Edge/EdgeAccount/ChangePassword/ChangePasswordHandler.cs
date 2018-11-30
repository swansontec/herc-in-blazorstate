namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.Send
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using Herc.Pwa.Client.Features.Base;
  using Herc.Pwa.Client.Features.Edge.Dtos;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using MediatR;
  using Microsoft.JSInterop;

  public class ChangePasswordHandler : BaseHandler<ChangePasswordAction, EdgeAccountState>
  {
    public ChangePasswordHandler(
      IStore aStore,
      IMediator aMediator) : base(aStore)
    {
      Mediator = aMediator;
    }

    private IMediator Mediator { get; }

    public override async Task<EdgeAccountState> Handle(ChangePasswordAction aSendAction, CancellationToken aCancellationToken)
    {
      var changePasswordDto = MapSendActionToChangePasswordDto(aSendAction);

      Console.WriteLine("Call the jsinterop to send via Edge");
      string transactionId = await JSRuntime.Current.InvokeAsync<string>(EdgeInteropMethodNames.EdgeCurrencyWalletInterop_Send, changePasswordDto);
      Console.WriteLine($"SendTransactionId:{transactionId}");

      return await Task.FromResult(EdgeCurrencyWalletsState);
    }

    private ChangePasswordDto MapSendActionToChangePasswordDto(ChangePasswordAction aChangePasswordAction)
    {
      return new ChangePasswordDto
      {
        NewPassord = aChangePasswordAction.Password
      };
    }
  }
}
