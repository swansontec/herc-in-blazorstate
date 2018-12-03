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

      RuleFor(aChangePassowrdAction => aChangePassowrdAction.NewPassword).NotEmpty();
      RuleFor(aChangePassowrdAction => aChangePassowrdAction.NewPassword).MinimumLength(6);

    }

  }
}
