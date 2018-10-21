namespace HercPwa2.Client.Features.Edge
{
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using HercPwa2.Client.Features.Base;
  using Microsoft.JSInterop;

  //TODO: this doesn't use any state so maybe doesn't need BaseHandler
  public partial class EdgeState
  {
    public class OpenLoginWindowEdgeActionHandler : BaseHandler<OpenLoginWindowEdgeAction, EdgeState>
    {
      public OpenLoginWindowEdgeActionHandler(IStore aStore) : base(aStore) { }

      public override async Task<EdgeState> Handle(OpenLoginWindowEdgeAction openLoginWindowEdgeRequest, CancellationToken cancellationToken)
      {
        //Console.WriteLine("**********");
        //Console.WriteLine(typeof(OnLoginRequest).AssemblyQualifiedName);
        //Console.WriteLine(typeof(OnLoginRequest).FullName);
        //Console.WriteLine("**********");
        await JSRuntime.Current.InvokeAsync<bool>("EdgeInterop.OpenLoginWindow");
        //Console.WriteLine("OpenLoginWindow Handle 2 cs");
        return EdgeState;
      }

      //public Task OnLogin()
      //{
      //  Console.WriteLine("OnLogin cs");
      //  return Task.CompletedTask;
      //}

      //public Task OnClose()
      //{
      //  Console.WriteLine("OnClose cs");
      //  return Task.CompletedTask;
      //}

    }
  }
}