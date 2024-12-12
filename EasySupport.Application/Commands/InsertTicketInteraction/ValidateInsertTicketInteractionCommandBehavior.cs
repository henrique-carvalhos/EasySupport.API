using EasySupport.Application.Models;
using EasySupport.Infrastructure.Persistence;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class ValidateInsertTicketInteractionCommandBehavior
        : IPipelineBehavior<InsertTicketInteractionCommand, ResultViewModel<int>>
    {
        private readonly EasySupportDbContext _context;
        public ValidateInsertTicketInteractionCommandBehavior(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketInteractionCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var ticketExists = _context.Tickets.Any(t => t.Id == request.TicketId);
            var attendantExists = _context.Users.Any(t => t.Id == request.AttendantId);
            var statusTicketExists = _context.StatusTickets.Any(t => t.Id == request.StatusTicketId);

            if(!ticketExists || !attendantExists || !statusTicketExists)
            {
                return ResultViewModel<int>.Error("Alguns desses parâmetros são inválidos: StatusTicket, Ticket ou atendente.");
            }

            return await next();
        }
    }
}
