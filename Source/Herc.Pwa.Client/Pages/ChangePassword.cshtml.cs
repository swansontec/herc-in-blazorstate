namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword;

  public class ChangePasswordModel : BaseComponent
  {
    public const string Route = "/changePassword";
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
    public ValidationResult ValidationResult { get; set; }

    protected async Task ChangePassword()
    {
      Console.WriteLine($"passwords a' changing, {NewPassword}");
      Console.WriteLine($"Confirm Password, {ConfirmPassword}");

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = NewPassword,
        ConfirmPassword = ConfirmPassword
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


