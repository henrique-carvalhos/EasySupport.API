using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteOriginService
{
    public class DeleteOriginServiceCommand : IRequest<ResultViewModel>
    {
        public DeleteOriginServiceCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
