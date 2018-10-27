namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using MediatR;

  public class EdgeModel : BaseComponent
  {
    public const string Route = "edge";
    public EdgeModel()
    {
      Console.WriteLine("EdgeModel constructor");
    }
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

    protected override async Task OnInitAsync()
    {
      Console.WriteLine("EdgeModel.OnInitAsync");
      Console.WriteLine(typeof(OnLoginAction).AssemblyQualifiedName);
      await InitializeEdge();
      await OpenLoginWindow();
      Console.WriteLine("After OpenLoginWindow");
    }

    protected override void OnInit()
    {
      Console.WriteLine("EdgeModel.OnInit");
    }
  }
}
