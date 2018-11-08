namespace Herc.Pwa.Client.Pages
{
  using Herc.Pwa.Client.Components;

  public class CounterPageModel : BaseComponent
  {
    internal void ButtonClick() =>
      Mediator.Send(new Features.Counter.IncrementCount.IncrementCounterRequest { Amount = 5 });
  }
}