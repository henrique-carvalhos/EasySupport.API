using EasySupport.Application.Commands.InsertCategory;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertCategoryValidator : AbstractValidator<InsertCategoryCommand>
    {
        public InsertCategoryValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");
        }
    }
}
