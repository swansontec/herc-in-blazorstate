namespace Herc.Pwa.Client.Services
{
  using System.Linq;

  public class BalanceFormater
  {
    public string GetBalanceDisplay(BalanceFormaterRequest aBalanceFormaterRequest)
    {
      string balance = aBalanceFormaterRequest.Balance;
      int granularity = aBalanceFormaterRequest.Granularity;
      int decimalPlacesToDisplay = aBalanceFormaterRequest.DecimalPlacesToDisplay;
      char decimalSeperator = aBalanceFormaterRequest.DecimalSeperator;

      string result = balance.PadLeft(granularity, '0');
      result = result.Insert(result.Length - granularity, decimalSeperator.ToString());
      result = result.Substring(0, result.Length - granularity + decimalPlacesToDisplay);
      if (result.First() == decimalSeperator)
      {
        result = $"0{result}";
      }
      return result;
    }
  }

  public class BalanceFormaterRequest
  {
    public string Balance { get; set; }
    public int Granularity { get; set; }
    public int DecimalPlacesToDisplay { get; set; }
    public char DecimalSeperator { get; set; } = '.';
  }
}
