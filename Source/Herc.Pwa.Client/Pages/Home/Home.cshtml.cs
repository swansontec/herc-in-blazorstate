namespace Herc.Pwa.Client.Pages.Home
{
  using System;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Pages.Edge;
  using Herc.Pwa.Client.Pages.Idology;

  public class HomeModel : BaseComponent
  {
    public const string Route = "";

    protected async override Task OnInitAsync()
    {
      // Are we in the proper state for this page?
      if (!EdgeState.IsLoggedIn)
      {
        // Route to Edge to Login
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = EdgePageModel.Route });
      }
      else if (!IdologyState.IsValid)
      {
        // Route them to Idology Page to verify
        await Mediator.Send(new BlazorState.Features.Routing.ChangeRouteRequest { NewRoute = IdologyModel.Route });
      }
      //else if (EdgeState.EdgeWalletInfo == null)
      //{
      //  const string EtheriumWalletType = "wallet:ethereum";
      //  // Fetch the acccount information we want.
      //  Console.WriteLine("Sending GetFirstWalletInfoAction");
      //  await Mediator.Send(new Features.Edge.GetFirstWalletInfoAction { Type = EtheriumWalletType });
      //}
    }
  }
}