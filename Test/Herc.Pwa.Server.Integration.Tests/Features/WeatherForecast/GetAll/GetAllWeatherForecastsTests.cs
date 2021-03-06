﻿namespace Herc.Pwa.Server.Integration.Tests.Features.WeatherForecast.GetAll
{
  using System.Threading.Tasks;
  using Herc.Pwa.Shared.Features.WeatherForecast;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;

  class GetAllWeatherForecastsTests
  {

    public GetAllWeatherForecastsTests(TestFixture aTestFixture)
    {
      Mediator = aTestFixture.ServiceProvider.GetService<IMediator>();
    }

    private IMediator Mediator { get; }

    public async Task ShouldGetAllWeatherForecasts()
    {
      // Arrange
      var getWeatherForecastsRequest = new GetWeatherForecastsRequest();

      //Act
      GetWeatherForecastsResponse getWeatherForecastsResponse =
        await Mediator.Send(getWeatherForecastsRequest);

      //Assert
      getWeatherForecastsResponse.WeatherForecasts.Count.ShouldBe(5);

    }
  }
}
