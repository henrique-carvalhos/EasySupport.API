using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class InsertTicketInteractionCommandHandler : IRequestHandler<InsertTicketInteractionCommand, ResultViewModel<int>>
    {
        private readonly ITicketInteractionRepository _repository;
        private readonly ITicketRepository _ticketRepository;
        private readonly INotificationService _notificationService;
        public InsertTicketInteractionCommandHandler(ITicketInteractionRepository repository, ITicketRepository ticketRepository, INotificationService notificationService)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _notificationService = notificationService;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketInteractionCommand request, CancellationToken cancellationToken)
        {
            var interaction = request.ToEntity();

            await _repository.AddAsync(interaction);

            var ticketResult = await _ticketRepository.GetByIdAsync(interaction.TicketId);

            if (ticketResult != null && interaction.Attendant.Role == "Admin")
            {
                ticketResult.AddAttendant(interaction.AttendantId);
                ticketResult.UpdateStatus(interaction.StatusTicketId);


                if (interaction.StatusTicket.Name.Contains("Resolvido"))
                {
                    ticketResult.UpdateSolution(interaction.SolutionTicketId ?? 0);
                }

                await _ticketRepository.UpdateAsync(ticketResult);
            }

            if (ticketResult != null)
            {
                await _notificationService.NotifyTicketInteraction(interaction, ticketResult);
            }

            return ResultViewModel<int>.Success(interaction.Id);
        }
    }
}
