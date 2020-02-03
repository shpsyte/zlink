using FluentValidation;

namespace Business.Models.Validations {
    public class TagDataValidations : AbstractValidator<TagData> {
        public TagDataValidations () {

            RuleFor (p => p.Id)
                .NotNull ();

            RuleFor (p => p.Data)
                .NotEmpty ();

        }
    }
}