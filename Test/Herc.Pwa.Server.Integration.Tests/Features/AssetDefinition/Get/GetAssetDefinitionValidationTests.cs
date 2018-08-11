namespace Herc.Pwa.Server.Integration.Tests.Features.AssetDefinition.Create
{
  using System.Threading.Tasks;
  using Herc.Pwa.Server.Entities;
  using Herc.Pwa.Server.Features.AssetDefinition.Get;
  using Herc.Pwa.Shared.Features.AssetDefinition;
  using Shouldly;
  using static SliceFixture;
  using FluentValidation.Results;

  class GetAssetDefinitionValidationTests : IntegrationTestBase
  {
    public void Should_be_Valid()
    {
      var getAssetDefinitionRequest = new GetAssetDefinitionRequest
      {
        AssetDefinitionId = 1
      };

      //Act
      var validator = new GetAssetDefinitionRequestValidator();
      ValidationResult validationResult = validator.Validate(getAssetDefinitionRequest);

      //Assert

      validationResult.IsValid.ShouldBeTrue();
    }

    public void Should_be_InValid()
    {
      var getAssetDefinitionRequest = new GetAssetDefinitionRequest
      {
        AssetDefinitionId = -1
      };

      //Act
      var validator = new GetAssetDefinitionRequestValidator();
      ValidationResult validationResult = validator.Validate(getAssetDefinitionRequest);

      //Assert

      validationResult.IsValid.ShouldBeFalse();
    }
  }
}
