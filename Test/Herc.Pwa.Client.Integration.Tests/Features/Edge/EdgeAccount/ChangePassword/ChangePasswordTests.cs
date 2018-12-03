namespace Herc.Pwa.Client.Integration.Tests.Features.Edge.EdgeAccount.ChangePassword

{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using FluentValidation;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount.ChangePassword;
  using Shouldly;

  class ChangePasswordTests
  {
    public void PasswordShouldNotBeEmpty()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction();
      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);
      ValidationFailure validationFailure = validationResult.Errors[0];

      validationFailure.PropertyName.ShouldBe(nameof(changePasswordAction.NewPassword));

      validationFailure.Severity.ShouldBe(Severity.Error);


    }

    public void PasswordShouldBeLongerThan6Char()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "shouldbeValid"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
      validationResult.Errors.Count.ShouldBe(0);

      //ValidationFailure validationFailure = validationResult.Errors[0];

      //validationFailure.PropertyName.ShouldBe(nameof(changePasswordAction.NewPassword));

      //validationFailure.Severity.ShouldBe(Severity.Error);

    }

  }
}
