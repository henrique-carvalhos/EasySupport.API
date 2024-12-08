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

            if(!ticketExists || attendantExists)
            {
                return ResultViewModel<int>.Error("Ticket ou atendente são inválidos");
            }

            return await next();
        }
    }
}
