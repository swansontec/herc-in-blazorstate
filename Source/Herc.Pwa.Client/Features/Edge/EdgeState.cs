namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Collections.Generic;
  using BlazorState;

  public partial class EdgeState : State<EdgeState>
  {
    public EdgeState() { }

    protected EdgeState(EdgeState aState) : this()
    {
      //UserName = aState.UserName;
      //IsLoggedIn = aState.IsLoggedIn;
      EdgeWalletInfo = EdgeWalletInfo?.Clone() as EdgeWalletInfo;
    }

    public EdgeWalletInfo EdgeWalletInfo { get; set; }
    //public bool IsLoggedIn { get; set; }
    //public string UserName { get; set; }

    public override object Clone() => new EdgeState(this);

    protected override void Initialize()
    {
      // Empty
    }
  }
  
}