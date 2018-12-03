namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using FluentValidation;
  using FluentValidation.Results;
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

      // I attempted to Validate the NewPW before calling Edge ChangePW method,
      // but didn't seem to work. 

      //var changePassValid = new ChangePasswordValidator();
      //var tester = new ChangePasswordAction
      //{
      //  NewPassword = "balloon"

      //};

      //ValidationResult results = changePassValid.Validate(tester);


      //Console.WriteLine(results);

      await Mediator.Send(new ChangePasswordAction
      {
        NewPassword = NewPassword
      }
      );

    }

  }
}


