namespace HercPwa2.Client.Features.Edge
{
  using System;
  using BlazorState.Features.JavaScriptInterop;
  using MediatR;
  using Microsoft.AspNetCore.Blazor;

  /// <summary>
  /// The request sent onLogin
  /// </summary>
  public class OnLoginAction : IRequest<EdgeState>
  {
    public OnLoginAction()
    {
      Console.WriteLine("OnLoginAction constructor");
    }

    public OnLoginAction(string aRequestAsJson)
    {
      Console.WriteLine($"OnLoginAction constructor: {aRequestAsJson}");
      //JsonRequest<OnLoginAction> jsonRequest =
      //  Microsoft.JSInterop.Deserialize<JsonRequest<OnLoginAction>>(aRequestAsJson);
      UserName = "Bob";
      //UserName = jsonRequest.Payload.UserName;
    }

    public string UserName { get; set; }
  }
}