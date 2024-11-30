using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateEnterprise
{
    public class UpdateEnterpriseCommand : IRequest<ResultViewModel>
    {
        public int EnterpriseId { get; set; }
        public string Name { get; set; }
    }
}
