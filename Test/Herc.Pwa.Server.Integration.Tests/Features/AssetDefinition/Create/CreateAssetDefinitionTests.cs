namespace Herc.Pwa.Server.Integration.Tests.Features.AssetDefinition.Create
{
  using System.Threading.Tasks;
  using Herc.Pwa.Shared.Features.AssetDefinition;
  using Shouldly;
  using static SliceFixture;

  class CreateAssetDefinitionTests : IntegrationTestBase
  {
    private const string AssetDefinitionName = "AnthemGold";
    private const string AssetDefinitionUrl = "https://anthembunker.com";

    public async Task Should_create_new_AssetDefinition()
    {
      //Arrange
      var createAssetDefinitionRequest = new CreateAssetDefinitionRequest()
      {
        AssetDefinition = new AssetDefinitionDto
        {
          Name = AssetDefinitionName,
          Url = AssetDefinitionUrl,
        }
      };

      var metricDefinitions = new MetricDefinitionDto[]
      {
        new MetricDefinitionDto { Name = "Assay", Default = "0.9999", UnitOfMeasure = "Fineness", Description="A Bar of Gold", SampleValue="0.9999", Regex= @"^0([.,])\d+" },
        new MetricDefinitionDto { Name = "Bar Serial #", Description="The serial number of the bar of gold", SampleValue="123456", UnitOfMeasure="Identifier" }
      };
      createAssetDefinitionRequest.AssetDefinition.MetricDefinitions.AddRange(metricDefinitions);

      //Act
      CreateAssetDefinitionResponse createAssetDefinitionResponse = await SendAsync(createAssetDefinitionRequest);

      //Assert
      createAssetDefinitionResponse.AssetDefinition.ShouldNotBeNull();
      AssetDefinitionDto assetDefinition = createAssetDefinitionResponse.AssetDefinition;
      assetDefinition.Name.ShouldBe(AssetDefinitionName);
      assetDefinition.Url.ShouldBe(AssetDefinitionUrl);
      assetDefinition.MetricDefinitions.Count.ShouldBe(2);
    }
  }
}
