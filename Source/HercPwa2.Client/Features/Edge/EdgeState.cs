namespace HercPwa2.Client.Features.Edge
{
  using BlazorState;

  public partial class EdgeState : State<EdgeState>
  {
    public EdgeState() { }

    protected EdgeState(EdgeState aState) : this()
    {
      UserName = aState.UserName;
      IsLoggedIn = aState.IsLoggedIn;
    }

    public string UserName { get; set; }

    public bool IsLoggedIn { get; set; }

    public override object Clone() => new EdgeState(this);

    protected override void Initialize()
    {
      // Empty
    }
  }
}