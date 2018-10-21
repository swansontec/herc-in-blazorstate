namespace HercPwa2.Shared.Features.WeatherForecast
{
  using HercPwa2.Shared.Features.Base;
  using MediatR;

  public class GetWeatherForecastsRequest : BaseRequest, IRequest<GetWeatherForecastsResponse>
  {
    public const string Route = "api/weatherForecast";
  }
}