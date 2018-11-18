namespace Herc.Pwa.Client.Components
{
  using System.Collections.Generic;
  using System.Linq;
  using FluentValidation.Results;

  public class ValidationModel : BaseComponent
  {
    public ValidationResult ValidationResult { get; set; }

    public IEnumerable<ValidationFailure> OtherErrors => 
      ValidationResult.Errors.Where(aValidationFailure => !aValidationFailure.ErrorMessage.Contains("must not be empty"));

    public IEnumerable<ValidationFailure> RequiredErrors =>
      ValidationResult.Errors.Where(aValidationFailure => aValidationFailure.ErrorMessage.Contains("must not be empty"));

    public bool ShowRequired => RequiredErrors.Any();

  }
}
