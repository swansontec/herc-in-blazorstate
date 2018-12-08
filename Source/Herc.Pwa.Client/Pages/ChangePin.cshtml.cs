namespace Herc.Pwa.Client.Pages
{
  using System;
  using System.Threading.Tasks;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.


  public class ChangePinModel : BaseComponent
  {
    public const string Route = "/changePassword";
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
    public bool SetPinLogin { get; set; }
    public ValidationResult ValidationResult { get; set; }

    public void OnGet()
    {
    }
  }
}