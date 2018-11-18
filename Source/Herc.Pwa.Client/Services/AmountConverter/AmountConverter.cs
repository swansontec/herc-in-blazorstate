namespace Herc.Pwa.Client.Services
{
  using System;
  using System.Linq;
  using FluentValidation;

  public class AmountConverter
  {
    public string GetFormatedAmount(FormatAmountRequest aFormatAmountRequest)
    {
      string balance = aFormatAmountRequest.Amount;
      int granularity = aFormatAmountRequest.Granularity;
      int decimalPlacesToDisplay = aFormatAmountRequest.DecimalPlacesToDisplay;
      char decimalSeperator = aFormatAmountRequest.DecimalSeperator;

      string result = balance.PadLeft(granularity, '0');
      result = result.Insert(result.Length - granularity, decimalSeperator.ToString());
      result = result.Substring(0, result.Length - granularity + decimalPlacesToDisplay);
      if (result.First() == decimalSeperator)
      {
        result = $"0{result}";
      }
      return result;
    }

    public string GetNativeAmount(GetNativeAmountRequest aGetNativeAmountRequest)
    {
      Console.WriteLine("Hello");
      var getNativeAmountRequestValidator = new GetNativeAmountRequestValidator();
      Console.WriteLine("constructed getNativeAmountRequestValidator");
      getNativeAmountRequestValidator.ValidateAndThrow(aGetNativeAmountRequest);
      Console.WriteLine("input is valid");

      string[] splitAmount = aGetNativeAmountRequest.Amount.Split(aGetNativeAmountRequest.DecimalSeperator);
      string decimalsplit = splitAmount.Length > 1 ? splitAmount[1] : "0";
      decimalsplit = decimalsplit.PadRight(aGetNativeAmountRequest.Granularity, '0').Substring(0, aGetNativeAmountRequest.Granularity);
      string result = $"{splitAmount[0]}{decimalsplit}";
      result = result.TrimStart(new char[] { '0' });
      result = result == "" ? "0" : result;
      Console.WriteLine($"result: {result}");
      return result;
    }
  }
}
