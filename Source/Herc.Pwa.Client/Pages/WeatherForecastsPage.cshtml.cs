namespace Herc.Pwa.Client.Pages
{
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;

  public class WeatherForecastsPageModel : BaseComponent
  {
    protected override async Task OnInitAsync() =>
      await Mediator.Send(new Features.WeatherForecast.FetchWeatherForecastsRequest());
  }
}