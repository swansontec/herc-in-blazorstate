namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.State;
  using Microsoft.AspNetCore.Blazor.Components;
  using Herc.Pwa.Client.Services;
  using System.Collections.Generic;

  public class EdgeTransactionListModel : BaseComponent
  {
    public List<EdgeTransaction> EdgeTransactions { get; set; }
    public string CurrencyCode { get; set; }
  }
}