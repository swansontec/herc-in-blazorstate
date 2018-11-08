namespace Herc.Pwa.Client.Features.Idology
{
  using BlazorState;

  public partial class IdologyState : State<IdologyState>
  {
    public IdologyState() { }

    protected IdologyState(IdologyState aState) : this()
    {
      IsValid = aState.IsValid;
    }

    public bool IsValid { get; set; }

    public override object Clone() => new IdologyState(this);

    protected override void Initialize() => IsValid = true;
  }
}