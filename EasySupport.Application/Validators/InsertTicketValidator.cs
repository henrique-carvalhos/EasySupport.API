using EasySupport.Application.Commands.InsertTicket;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertTicketValidator : AbstractValidator<InsertTicketCommand>
    {
        public InsertTicketValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Descrição não pode ser vazio");
        }
    }
}
