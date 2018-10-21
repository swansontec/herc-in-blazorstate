namespace HercPwa2.Client.Components.Iconic
{
  using Microsoft.AspNetCore.Blazor.Components;
  public class HercButtonIconModel : BaseComponent
  {

    [Parameter] protected string FillColor { get; set; } = "purple";

    [Parameter] protected int Size { get; set; } = 16;
  }
}
