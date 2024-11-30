using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteEnterprise
{
    public class DeleteEnterpriseCommand : IRequest<ResultViewModel>
    {
        public DeleteEnterpriseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
