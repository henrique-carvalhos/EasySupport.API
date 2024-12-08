using EasySupport.Application.Commands.InsertDepartment;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertDepartmentValidator : AbstractValidator<InsertDepartmentCommand>
    {
        public InsertDepartmentValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");

        }
    }
}
