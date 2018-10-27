namespace Herc.Pwa.Client.Features.Edge
{
  using MediatR;

  /// <summary>
  /// The request sent onLogin
  /// </summary>
  public class OnLoginAction : IRequest<EdgeState>
  {
    public string UserName { get; set; }
    public string WalletId { get; set; }

  }
}