using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class InsertTicketInteractionCommand : IRequest<ResultViewModel<int>>
    {
        public int TicketId { get;  set; }
        public int AttendantId { get;  set; }
        public int StatusTicketId { get; set; }
        public string Message { get;  set; }
        public DateTime CreatedAt { get;  set; }

        public TicketInteraction ToEntity()
            => new(TicketId, AttendantId, StatusTicketId,Message);
    }
}
