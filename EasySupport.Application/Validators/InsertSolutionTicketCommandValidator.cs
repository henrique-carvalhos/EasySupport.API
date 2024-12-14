using EasySupport.Application.Commands.InsertSolutionTicket;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertSolutionTicketCommandValidator : AbstractValidator<InsertSolutionTicketCommand>
    {
        public InsertSolutionTicketCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");
        }
    }
}
