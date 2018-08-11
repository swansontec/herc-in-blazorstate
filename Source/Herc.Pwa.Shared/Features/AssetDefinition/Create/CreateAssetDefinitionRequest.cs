namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using Herc.Pwa.Shared.Features.Base;
  using MediatR;

  public class CreateAssetDefinitionRequest : BaseRequest, IRequest<CreateAssetDefinitionResponse>
  {
    public const string Route = "api/CreateAssetDefinition";
    public AssetDefinitionDto AssetDefinition { get; set; }
  }
}