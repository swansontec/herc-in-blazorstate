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
    public void PasswordShouldNotBeValid()
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

    public void PasswordShouldNotBeLongEnough()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "Shor!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(2);
      //additional error of "NewPassword" not being in the correct format


    }


    public void PasswordShouldBeValid()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "should3!NotbeValid"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
      validationResult.Errors.Count.ShouldBe(0);


    }

    public void PasswordShouldContainCapNumSpecChar()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "shoulDb3Valid!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(true);
      validationResult.Errors.Count.ShouldBe(0);
     
    }

    public void PasswordShouldFailBecauseOfSpace()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "shoulD not b3Valid!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }


    public void PasswordShouldFailBecauseOfNoNum()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "ShouldNotBeValidMissingNumber!"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }

    public void PasswordShouldFailBecauseOfNoSpecChar()
    {
      // Arrange

      var changePasswordAction = new ChangePasswordAction
      {
        NewPassword = "NoSp3cialChar"
      };

      var changePasswordValidator = new ChangePasswordValidator();

      // Act

      ValidationResult validationResult = changePasswordValidator.Validate(changePasswordAction);

      // Assert
      validationResult.IsValid.ShouldBe(false);
      validationResult.Errors.Count.ShouldBe(1);

    }

  }
}
