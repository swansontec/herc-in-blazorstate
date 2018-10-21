namespace HercPwa2.Client.Features.Base
{
  using BlazorState;
  using HercPwa2.Client.Features.Application;
  using HercPwa2.Client.Features.Counter;
  using HercPwa2.Client.Features.Edge;
  using HercPwa2.Client.Features.WeatherForecast;
  using MediatR;

  /// <summary>
  /// Base Handler that makes it easy to access state
  /// </summary>
  /// <typeparam name="TRequest"></typeparam>
  /// <typeparam name="TState"></typeparam>
  public abstract class BaseHandler<TRequest, TState> : BlazorState.RequestHandler<TRequest, TState>
    where TRequest : IRequest<TState>
    where TState : IState
  {
    public BaseHandler(IStore aStore) : base(aStore) { }

    public CounterState CounterState => Store.GetState<CounterState>();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public WeatherForecastsState WeatherForecastsState => Store.GetState<WeatherForecastsState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
  }
}