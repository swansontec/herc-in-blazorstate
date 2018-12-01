namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Shared;
  using Microsoft.AspNetCore.Blazor.Components;

  public class ChangePasswordModel : BaseComponent
  {
    public const string Route = "/changePassword";
    public string NewPassword { get; set; }

    protected async Task ChangePassword()
    {
      Console.WriteLine($"passwords a' changing, {NewPassword}");
     
      await Mediator.Send(new ChangePasswordAction
      {
        NewPassword = NewPassword
      }
      );
     
    }

  }
}


