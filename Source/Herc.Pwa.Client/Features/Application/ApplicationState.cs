namespace Herc.Pwa.Client.Features.Application
{
  using BlazorState;

  public partial class ApplicationState : State<ApplicationState>
  {
    public ApplicationState() { }

    protected ApplicationState(ApplicationState aState) : this()
    {
      Name = aState.Name;
    }

    public string Name { get; private set; }
    public string Version { get; set; }

    public override object Clone() => new ApplicationState(this);

    protected override void Initialize()
    {
      Name = "Herc Progressive Web Application";
      Version = "0.0.1";
    }
  }
}