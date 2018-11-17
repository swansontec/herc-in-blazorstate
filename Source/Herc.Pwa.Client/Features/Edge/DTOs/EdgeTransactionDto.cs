namespace Herc.Pwa.Client.Features.Edge.DTOs
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class EdgeTransactionDto
    {
    public string Txid { get; set; }
    public DateTime Date { get; set; }
    public string CurrencyCode { get; set; }
    public int BlockHeight { get; set; }
  }
}
