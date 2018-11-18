using System.Threading.Tasks;
using Herc.Pwa.Client.Services;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Services
{
  public class BalanceFormaterTests
  {

    public void Should_Display_Proper_Decimals()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "9979261128182853278",
        Granularity = 18,
        DecimalPlacesToDisplay = 3,
        DecimalSeperator = '.'
      };

      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("9.979");
    }
    public void Should_Prefix_Zero()
    {
      var balanceFormater = new AmountConverter();
      var balanceFormaterRequest = new FormatAmountRequest
      {
        Amount = "0123",
        Granularity = 5,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };
      balanceFormater.GetFormatedAmount(balanceFormaterRequest).ShouldBe("0.0012");
    }

  }
}