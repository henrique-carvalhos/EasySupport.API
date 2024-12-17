using EasySupport.Application.Models;
using EasySupport.Core.Emums;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicket
{
    public class InsertTicketCommand : IRequest<ResultViewModel<int>>
    {
        public int ClientId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int? AttendantId { get; set; }
        public int StatusTicketId { get; set; }
        public int OriginServiceId { get; set; }
        public int? SolutionTicketId { get; set; }
        public Priority Priority { get; set; }
        public string Description { get; set; }

        public Ticket ToEntity()
            => new(ClientId, AttendantId, CategoryId, SubcategoryId, StatusTicketId, OriginServiceId, SolutionTicketId ,Priority, Description);
    }
}
