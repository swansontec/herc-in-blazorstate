namespace HercPwa2.Client.Pages
{
  using HercPwa2.Client.Components;

  public class CounterPageModel : BaseComponent
  {
    internal void ButtonClick() =>
      Mediator.Send(new Features.Counter.IncrementCount.IncrementCounterRequest { Amount = 5 });
  }
}