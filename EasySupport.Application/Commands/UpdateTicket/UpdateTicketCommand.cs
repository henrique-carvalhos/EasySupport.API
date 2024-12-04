using EasySupport.Application.Models;
using EasySupport.Core.Emums;
using MediatR;

namespace EasySupport.Application.Commands.UpdateTicket
{
    public class UpdateTicketCommand : IRequest<ResultViewModel>
    {
        public int TicketId { get; set; }
        public int ClientId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int StatusTicketId { get; set; }
        public Priority Priority { get; set; }
    }
}
