using EasySupport.Application.Commands.InsertUser;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertUserValidator : AbstractValidator<InsertUserCommand>
    {
        public InsertUserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("E-mail não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");

            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage("Role não pode ser vazio")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo é de 50 caracteres");
        }
    }
}
