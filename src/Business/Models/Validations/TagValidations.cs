using FluentValidation;

namespace Business.Models.Validations {
    public class TagValidations : AbstractValidator<Tag> {
        public TagValidations () {
            RuleFor (p => p.Id)
                .NotNull ();

            // RuleFor (p => p.Name)
            //     .NotEmpty ()
            //     .Length (1, int.MaxValue);

            // RuleFor (p => p.TargetLink)
            //     .NotEmpty ().Length (10, int.MaxValue);

        }
    }
}