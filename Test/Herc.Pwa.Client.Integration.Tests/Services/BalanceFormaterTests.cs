using System.Threading.Tasks;
using Herc.Pwa.Client.Services;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Services
{
  public class BalanceFormaterTests
  {

    public async Task Should_Display_Proper_Decimals()
    {
      var balanceFormater = new BalanceFormater();
      var balanceFormaterRequest = new BalanceFormaterRequest
      {
        Balance = "9979261128182853278",
        Granularity = 18,
        DecimalPlacesToDisplay = 3,
        DecimalSeperator = '.'
      };

      balanceFormater.GetBalanceDisplay(balanceFormaterRequest).ShouldBe("9.979");
    }
    public async Task Should_Prefix_Zero()
    {
      var balanceFormater = new BalanceFormater();
      var balanceFormaterRequest = new BalanceFormaterRequest
      {
        Balance = "0123",
        Granularity = 5,
        DecimalPlacesToDisplay = 4,
        DecimalSeperator = '.'
      };
      balanceFormater.GetBalanceDisplay(balanceFormaterRequest).ShouldBe("0.0012");
    }

  }
}