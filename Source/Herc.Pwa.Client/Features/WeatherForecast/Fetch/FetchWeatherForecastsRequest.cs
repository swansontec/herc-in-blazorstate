namespace Herc.Pwa.Client.Features.WeatherForecast
{
  using MediatR;

  public class FetchWeatherForecastsRequest : IRequest<WeatherForecastsState> { }
}