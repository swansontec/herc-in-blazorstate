using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword
{
  public class ChangePasswordValidator : AbstractValidator<ChangePasswordAction>

  {
    public ChangePasswordValidator()
    {
      CascadeMode = CascadeMode.StopOnFirstFailure;

      RuleFor(aChangePasswordAction => aChangePasswordAction.NewPassword).NotEmpty();
      RuleFor(aChangePasswordAction => aChangePasswordAction.NewPassword).MinimumLength(6);
      RuleFor(aChangePasswordAction => aChangePasswordAction.NewPassword).Matches(@"^(?!.* )(?=.*\d)(?=.*[A-Z])(?=.*\W).{6,}$");
    }

  }
}
