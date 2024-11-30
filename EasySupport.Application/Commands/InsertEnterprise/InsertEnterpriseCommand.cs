using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertEnterprise
{
    public class InsertEnterpriseCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public Enterprise ToEntity()
            => new(Name);
    }
}
