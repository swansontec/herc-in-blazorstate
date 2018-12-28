namespace Herc.Pwa.Client.Features.Edge.State
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

 public class EdgeTransaction : ICloneable
  {
    public int Date { get; set; }
    public string CurrencyCode { get; set; }
    public int BlockHeight { get; set; }
    public string NativeAmount { get; set; }
    public string NetworkFee { get; set; }
    public List<string> OurReceiveAddresses { get; set; }
    public string SignedTx { get; set; }
    public string ParentNetworkFee { get; set; }

    public object Clone()
    {
      var clone = MemberwiseClone() as EdgeTransaction;

      clone.OurReceiveAddresses = new List<string>(OurReceiveAddresses);

      return clone;
    }

  };
}

