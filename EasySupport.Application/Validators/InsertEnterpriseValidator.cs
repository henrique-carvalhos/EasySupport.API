using EasySupport.Application.Commands.InsertEnterprise;
using FluentValidation;

namespace EasySupport.Application.Validators
{
    public class InsertEnterpriseValidator : AbstractValidator<InsertEnterpriseCommand>
    {
        public InsertEnterpriseValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .MaximumLength(150)
                .WithMessage("Tamanho máximo é de 150 caracteres");
        }
    }
}
