using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteStatusTicket
{
    public class DeleteStatusTicketCommand : IRequest<ResultViewModel>
    {
        public DeleteStatusTicketCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
