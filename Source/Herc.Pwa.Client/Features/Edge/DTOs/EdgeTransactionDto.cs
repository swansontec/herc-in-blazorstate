namespace Herc.Pwa.Client.Features.Edge.Dtos
{
  using System;
  using System.Collections.Generic;

  public class EdgeTransactionDto
  {
    public DateTime Date { get; set; }
    public string CurrencyCode { get; set; }
    public int BlockHeight { get; set; }
    public string NativeAmount { get; set; }
    public string NetworkFee { get; set; }
    public List<string> OurReceiveAddresses { get; set; }
    public string SignedTx { get; set; }
    public string ParentNetworkFee { get; set; }
  }
}

