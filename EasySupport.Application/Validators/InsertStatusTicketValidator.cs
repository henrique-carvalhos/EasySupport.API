using EasySupport.Application.Commands.InsertStatusTicket;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertStatusTicketValidator : AbstractValidator<InsertStatusTicketCommand>
    {
        public InsertStatusTicketValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");
        }
    }
}
