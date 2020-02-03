using Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services {
    public abstract class BaseServices {
        protected void Notificar (ValidationResult validationResult) {
            foreach (var error in validationResult.Errors) {
                Notificar (error.ErrorMessage);

            }
        }

        protected void Notificar (string message) {
            // propagar para até a camada de apresentação
        }

        protected bool ExecutarValidacao<T, E> (T validacao, E entidade) where T : AbstractValidator<E> where E : Entity {
            var validator = validacao.Validate (entidade);

            if (validator.IsValid) return true;

            Notificar (validator);
            return false;

        }

    }
}