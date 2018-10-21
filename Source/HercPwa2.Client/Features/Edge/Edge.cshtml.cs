namespace HercPwa2.Client.Features.Edge
{
  using System;
  using System.Threading.Tasks;
  using HercPwa2.Client.Components;
  using MediatR;

  public class EdgeModel : BaseComponent
  {
    public EdgeModel()
    {
      Console.WriteLine("EdgeModel constructor");
      StaticMediator = Mediator;
      if (StaticMediator == null)
        Console.WriteLine("StaticMediator == null in constructor");
    }
    public static IMediator StaticMediator { get; set; }
    public async Task InitializeEdge()
    {
      Console.WriteLine("InitializeEdge Page.cs");
      await Mediator.Send(new InitailizeEdgeAction());
      Console.WriteLine("Edge Initialized");
    }

    public async Task OpenLoginWindow()
    {
      Console.WriteLine("OpenLoginWindow Page.cs");
      await Mediator.Send(new OpenLoginWindowEdgeAction());
    }

    protected override void OnInit()
    {
      StaticMediator = Mediator;
      if (StaticMediator != null)
        Console.WriteLine("StaticMediator assigned");
    }


    /// <summary>
    /// Call back from Edge
    /// </summary>
    /// <returns></returns>
    public static async Task OnLogin(string aUserName)
    {
      Console.WriteLine($"On Login: {aUserName}");

      var onLoginRequest = new OnLoginAction
      {
        UserName = aUserName
      };
      Console.WriteLine($"onLoginRequest.UserName: {onLoginRequest.UserName}");
      if (StaticMediator == null)
        Console.WriteLine("StaticMediator == null");
      await StaticMediator.Send(onLoginRequest);
      Console.WriteLine($"On Login: {aUserName} complete");
    }
  }
}
