namespace Herc.Pwa.Shared.Features.AssetDefinition
{
  public class MetricDefinitionDto
  {
    public MetricDefinitionDto() { }

    public int AssetDefinitionId { get; set; }
    public string Default { get; set; }
    public string Description { get; set; }
    public int MetricDefinitionId { get; set; }
    public string Name { get; set; }
    public string Regex { get; set; }
    public string SampleValue { get; set; }
    public string UnitOfMeasure { get; set; }

    public object Clone() => (MetricDefinitionDto)MemberwiseClone(); // shallow clone is all we need
  }
}
