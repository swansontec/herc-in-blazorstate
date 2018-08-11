namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using System;
  using Herc.Pwa.Shared.Features.Base;

  /// <summary>
  /// Returns the AssetDefinitionDto if found
  /// </summary>
  public class GetAssetDefinitionResponse : BaseResponse
  {
    public GetAssetDefinitionResponse() { }
    public GetAssetDefinitionResponse(Guid aRequestId) : base(aRequestId) { }
    public AssetDefinitionDto AssetDefinition { get; set; }
  }
}
