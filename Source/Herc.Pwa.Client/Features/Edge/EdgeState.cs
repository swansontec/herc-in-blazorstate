namespace Herc.Pwa.Client.Features.Edge
{
  using System.Collections.Generic;
  using BlazorState;

  public partial class EdgeState : State<EdgeState>
  {
    public EdgeState() { }

    protected EdgeState(EdgeState aState) : this()
    {
      UserName = aState.UserName;
      IsLoggedIn = aState.IsLoggedIn;
    }

    public bool IsLoggedIn { get; set; }
    public string UserName { get; set; }
    public Wallet Wallet { get; set; }

    public override object Clone() => new EdgeState(this);

    protected override void Initialize()
    {
      // Empty
    }
  }

  public class Wallet
  {
    public List<string> AppIds { get; set; }
    public bool Archived { get; set; }
    public bool Deleted { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public int sortIndex { get; set; }
    public string Type { get; set; }
  }

  //{"type":"wallet:ethereum","id":"YXyIEQksd5ZxFd1NMMrtzUa6LpgUdf0BrSgHEZA9nu4=","archived":false,"deleted":false,"sortIndex":2,"keys":{"ethereumKey":"809b95d964c67de3fe07aa653261db6c4d9952ba981de5cd4bc0383681cf1b1f","dataKey":"UHhqCtK/cEKZLlpnQTdzhXmTKCNmb3Is6boaMHjXw+E=","syncKey":"/zd3jcnEQJMOO5f0NfZ5HWaGJ/M="},"appIds":["com.mydomain.myapp"]}
}