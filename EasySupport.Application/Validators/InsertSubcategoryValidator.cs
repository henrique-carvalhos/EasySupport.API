using EasySupport.Application.Commands.InsertSubcategories;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertSubcategoryValidator : AbstractValidator<InsertSubcategoriesCommand>
    {
        public InsertSubcategoryValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(50)
                .WithMessage("Tamanho máximo é de 50 caracteres");
        }
    }
}
