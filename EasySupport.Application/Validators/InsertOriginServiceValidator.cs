using EasySupport.Application.Commands.InsertOriginService;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertOriginServiceValidator : AbstractValidator<InsertOriginServiceCommand>
    {
        public InsertOriginServiceValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");
        }
    }
}
