namespace HercPwa2.Client.Features.Edge
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using BlazorState;
  using HercPwa2.Client.Features.Base;
  using Microsoft.JSInterop;

  public partial class EdgeState
  {

    public class InitializeEdgeActionHandler : BaseHandler<InitailizeEdgeAction, EdgeState>
    {
      public InitializeEdgeActionHandler(IStore aStore) : base(aStore) { }

      private const string jsFunctionName = "EdgeInterop.InitializeEdge";
      public override async Task<EdgeState> Handle(InitailizeEdgeAction aInitailizeEdgeRequest, CancellationToken aCancellationToken)
      {
        Console.WriteLine($"Invoke the JavaScript method: {jsFunctionName}");
        await JSRuntime.Current.InvokeAsync<bool>(jsFunctionName);
        
        return EdgeState;
      }
    }
  }
}