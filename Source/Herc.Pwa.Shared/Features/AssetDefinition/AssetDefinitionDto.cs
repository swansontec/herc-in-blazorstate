namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  using System;
  using System.Collections.Generic;

  public class AssetDefinitionDto : ICloneable
  {
    public AssetDefinitionDto()
    {
      MetricDefinitions = new List<MetricDefinitionDto>();
    }

    protected AssetDefinitionDto(AssetDefinitionDto aAssetDefinition) : this()
    {
      Name = aAssetDefinition.Name;
      Url = aAssetDefinition.Url;
      Logo = aAssetDefinition.Logo;

      foreach (MetricDefinitionDto metricDefinition in aAssetDefinition.MetricDefinitions)
      {
        MetricDefinitions.Add((MetricDefinitionDto) metricDefinition.Clone());
      }
    }

    public List<MetricDefinitionDto> MetricDefinitions { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public byte[] Logo { get; set; }
    public object Clone() => new AssetDefinitionDto(this);
  }
}