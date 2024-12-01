using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateStatusTicket
{
    public class UpdateStatusTicketCommand : IRequest<ResultViewModel>
    {
        public int StatusTicketId { get; set; }
        public string Name { get; set; }
    }
}
