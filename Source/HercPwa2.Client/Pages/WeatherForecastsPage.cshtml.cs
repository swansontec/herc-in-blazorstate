namespace HercPwa2.Client.Pages
{
  using System.Threading.Tasks;
  using HercPwa2.Client.Components;

  public class WeatherForecastsPageModel : BaseComponent
  {
    protected override async Task OnInitAsync() =>
      await Mediator.Send(new Features.WeatherForecast.FetchWeatherForecastsRequest());
  }
}