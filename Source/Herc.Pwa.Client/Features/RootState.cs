namespace Herc.Pwa.Client.Features
{
  using BlazorState;
  using Herc.Pwa.Client.Features.Application;
  using Herc.Pwa.Client.Features.Counter;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Features.WeatherForecast;

  public class RootState
  {
    public RootState(IStore aStore)
    {
      Store = aStore;
    }
    protected IStore Store { get; set; }

    public CounterState CounterState => Store.GetState<CounterState>();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public WeatherForecastsState WeatherForecastsState => Store.GetState<WeatherForecastsState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
  }
}
