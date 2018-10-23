namespace HercPwa2.Client.Components
{
  using System;
  using System.Collections.Concurrent;
  using BlazorState.Behaviors.ReduxDevTools;
  using HercPwa2.Client.Features.Application;
  using HercPwa2.Client.Features.Counter;
  using HercPwa2.Client.Features.Edge;
  using HercPwa2.Client.Features.Idology;
  using HercPwa2.Client.Features.WeatherForecast;

  /// <summary>
  /// Makes access to the State a little easier and by inheriting from
  /// BlazorStateDevToolsComponent it allows for ReduxDevTools operation.
  /// </summary>
  /// <remarks>
  /// In production one would NOT be required to use these base components
  /// But would be required to properly implement the required interfaces.
  /// one could conditionally inherit from BlazorComponent for production build.
  /// </remarks>
  public class BaseComponent : BlazorStateDevToolsComponent
  {
    static ConcurrentDictionary<string, int> s_InstanceCounts = new ConcurrentDictionary<string, int>();
    public BaseComponent()
    {
      string name = GetType().Name;
      int count = s_InstanceCounts.AddOrUpdate(name, 1, (aKey, aValue) => aValue + 1);
      
      Id = $"{name}-{count}";
      Console.WriteLine(Id);
    }


    ~BaseComponent()
    {
      Console.WriteLine("Destroying something");
      string name = GetType().Name;
      s_InstanceCounts[name]--;
    }

    public string Id { get; }

    public string TestId { get; set; }

    public Guid Guid { get; } = Guid.NewGuid();
    public ApplicationState ApplicationState => Store.GetState<ApplicationState>();
    public CounterState CounterState => Store.GetState<CounterState>();
    public WeatherForecastsState WeatherForecastsState => Store.GetState<WeatherForecastsState>();
    public EdgeState EdgeState => Store.GetState<EdgeState>();
    public IdologyState IdologyState => Store.GetState<IdologyState>();

  }
}