namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
  using BlazorState;

  public partial class EdgeCurrencyWalletsState : State<EdgeCurrencyWalletsState>
  {
    public EdgeCurrencyWalletsState()
    {
      EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>();
    }

    protected EdgeCurrencyWalletsState(EdgeCurrencyWalletsState aEdgeCurrencyWalletsState) : this()
    {

      aEdgeCurrencyWalletsState
        .EdgeCurrencyWallets
        .ToList()
        .ForEach
        (
          aKeyValuePair =>
            EdgeCurrencyWallets[aKeyValuePair.Key] =
              aKeyValuePair.Value.Clone() as EdgeCurrencyWallet
        );

      SelectedEdgeCurrencyWalletId = aEdgeCurrencyWalletsState.SelectedEdgeCurrencyWalletId;
    }

    public Dictionary<string, EdgeCurrencyWallet> EdgeCurrencyWallets { get; set; }

    public string SelectedEdgeCurrencyWalletId { get; set; }

    public EdgeCurrencyWallet SelectedEdgeCurrencyWallet {
      get {
        if ( SelectedEdgeCurrencyWalletId != null &&
            EdgeCurrencyWallets.ContainsKey(SelectedEdgeCurrencyWalletId))
        {
          return EdgeCurrencyWallets[SelectedEdgeCurrencyWalletId];
        };
        if(EdgeCurrencyWallets.Count > 0)
        {
          return EdgeCurrencyWallets.First().Value;
        }
        return null;
      }
    }
    
    public override object Clone() => new EdgeCurrencyWalletsState(this);

    protected override void Initialize()
    {
      // Default will be an empty List
    }

    /// <summary>
    /// Use in Tests ONLY, to initialize the State
    /// </summary>
    /// <param name="aCount"></param>
    //public void Initialize()
    //{
    //  ThrowIfNotTestAssembly(Assembly.GetCallingAssembly());
    //  Count = aCount;
    //}
  }

}