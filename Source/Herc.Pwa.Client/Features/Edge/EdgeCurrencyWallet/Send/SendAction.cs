namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.Send
{
  using Herc.Pwa.Shared.Enumerations.FeeOption;
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class SendAction : BaseRequest, IRequest<EdgeCurrencyWalletsState>
  {
    public string EdgeCurrencyWalletId { get; set; }
    public string DestinationAddress { get; set; }

    /// <summary>
    /// The amount without decimals. For ETH the native amount unit is called wei. 1x10^18 wei = 1 ETH
    /// </summary>
    public string NativeAmount { get; set; }

    public string CurrencyCode { get; set; }

    public FeeOption Fee { get; set; }
  }
}