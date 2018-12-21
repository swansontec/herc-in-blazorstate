namespace Herc.Pwa.Client.Features.Edge.State
{
  using System.Collections.Generic;

  public class EdgeTransaction
  {
    public int Date { get; set; }
    public string CurrencyCode { get; set; }
    public int BlockHeight { get; set; }
    public int NativeAmount { get; set; }
    public string NetworkFee { get; set; }
    public List<string> OurReceiveAddresses { get; set; }
    public string SignedTx { get; set; }
    public string ParentNetworkFee { get; set; }
    //metadata?: EdgeMetadata,
    //otherParams: any,
    //public <wallet?: EdgeCurrencyWallet
  };
}

