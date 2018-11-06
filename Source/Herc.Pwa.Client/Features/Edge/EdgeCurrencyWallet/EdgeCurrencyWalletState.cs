namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Linq;
  using BlazorState;

  public partial class EdgeCurrencyWalletState : State<EdgeCurrencyWalletState>
  {
    public EdgeCurrencyWalletState() { }

    protected EdgeCurrencyWalletState(EdgeCurrencyWalletState aEdgeCurrencyWalletState) : this()
    {
      EdgeCurrencyWallet = aEdgeCurrencyWalletState.EdgeCurrencyWallet?.Clone() as EdgeCurrencyWallet;
    }

    private EdgeCurrencyWallet _EdgeCurrencyWallet;

    public EdgeCurrencyWallet EdgeCurrencyWallet
    {
      get => _EdgeCurrencyWallet;
      set
      {
        _EdgeCurrencyWallet = value;
        SelectedCurrencyCode = value?.EdgeBalances.FirstOrDefault().CurrencyCode;
      }
    }

    public string SelectedCurrencyCode { get; set; }

    public override object Clone() => new EdgeCurrencyWalletState(this);

    protected override void Initialize()
    {
      // Empty
    }
  }

}