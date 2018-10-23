namespace HercPwa2.Client.Features
{
  using BlazorState;
  using HercPwa2.Client.Features.Application;
  using HercPwa2.Client.Features.Counter;
  using HercPwa2.Client.Features.Edge;
  using HercPwa2.Client.Features.WeatherForecast;

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
