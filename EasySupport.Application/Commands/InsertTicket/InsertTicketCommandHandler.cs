using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicket
{
    public class InsertTicketCommandHandler : IRequestHandler<InsertTicketCommand, ResultViewModel<int>>
    {
        private readonly ITicketRepository _repository;
        private readonly INotificationService _notificationService;
        public InsertTicketCommandHandler(ITicketRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = request.ToEntity();

            await _repository.AddAsync(ticket);

            var ticketResult = await _repository.GetByIdAsync(ticket.Id);

            if (ticketResult != null)
            {
                await _notificationService.NotifyTicketCreated(ticketResult);
            }

            return ResultViewModel<int>.Success(ticket.Id);
        }
    }
}
