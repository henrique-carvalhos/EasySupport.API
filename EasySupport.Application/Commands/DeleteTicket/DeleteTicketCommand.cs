using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteTicket
{
    public class DeleteTicketCommand : IRequest<ResultViewModel>
    {
        public DeleteTicketCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
