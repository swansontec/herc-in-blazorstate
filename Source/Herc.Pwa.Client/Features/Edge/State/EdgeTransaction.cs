namespace Herc.Pwa.Client.Features.Edge.State
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  static class Extensions
    {
    internal static IList<EdgeTransaction> NewClone<EdgeTransaction>(this IList<EdgeTransaction> listToClone) where EdgeTransaction : ICloneable => listToClone.Select(aItem => (EdgeTransaction)aItem.Clone()).ToList();
     }
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

