namespace Herc.Pwa.Client.Features.Edge
{
  using System;

  public class EdgeBalance : ICloneable
  {
    public string Balance { get; set; }
    public string CurrencyCode { get; set; }

    public object Clone() => MemberwiseClone();

  }
}