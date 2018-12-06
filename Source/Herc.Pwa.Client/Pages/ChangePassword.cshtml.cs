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
    public bool DisplayConfirm { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected async Task ChangePassword()
    {
      Console.WriteLine($"passwords a' changing, {NewPassword}");

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = NewPassword
      };

      var validator = new ChangePasswordValidator();
      ValidationResult = validator.Validate(changePasswordAction);
      Console.WriteLine(ValidationResult);
      if (ValidationResult.IsValid)
      {
        await Mediator.Send(changePasswordAction);
      }

    }

  }
}


