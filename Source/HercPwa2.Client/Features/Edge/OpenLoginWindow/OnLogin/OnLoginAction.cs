namespace HercPwa2.Client.Features.Edge
{

  using MediatR;

  /// <summary>
  /// The request sent onLogin
  /// </summary>
  public class OnLoginAction : IRequest<EdgeState>
  {
    public OnLoginAction() { }

    //public OnLoginRequest(string aRequestAsJson) : this()
    //{
    //  JsonRequest<OnLoginRequest> jsonRequest =
    //    JsonUtil.Deserialize<JsonRequest<OnLoginRequest>>(aRequestAsJson);

    //  UserName = jsonRequest.Payload.UserName;
    //}

    public string UserName { get; set; }
  }
}