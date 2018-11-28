namespace Herc.Pwa.Client.Layouts.HercLayout.HercHeader
{
  using Herc.Pwa.Client.Components;
  using Microsoft.AspNetCore.Blazor.Components;

  public class IconBarModel : BaseComponent
  {
    [Parameter] protected int IconSize { get; set; } = 16;
    [Parameter] protected string IconFillColor { get; set; } = "pink";
  }
}
