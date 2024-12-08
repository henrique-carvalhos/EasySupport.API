using EasySupport.Application.Commands.InsertTicketInteraction;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertTicketInteractionValidator : AbstractValidator<InsertTicketInteractionCommand>
    {
        public InsertTicketInteractionValidator()
        {
            RuleFor(i => i.Message)
                .NotEmpty()
                .WithMessage("Mensagem não pode ser vazio")
                .MaximumLength(255)
                .WithMessage("Tamanho máximo é de 255 caracteres");
        }
    }
}
