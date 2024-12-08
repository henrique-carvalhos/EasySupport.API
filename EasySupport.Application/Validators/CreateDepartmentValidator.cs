using EasySupport.Application.Commands.InsertDepartment;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class CreateDepartmentValidator : AbstractValidator<InsertDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 50 caracteres");

        }
    }
}
