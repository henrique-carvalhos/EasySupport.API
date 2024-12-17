using EasySupport.Application.Models;
using EasySupport.Application.Notification.TicketInteractionCreated;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class InsertTicketInteractionCommandHandler : IRequestHandler<InsertTicketInteractionCommand, ResultViewModel<int>>
    {
        private readonly ITicketInteractionRepository _repository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMediator _mediator;   
        public InsertTicketInteractionCommandHandler(ITicketInteractionRepository repository, ITicketRepository ticketRepository, IMediator mediator)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _mediator = mediator;
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

            var ticket = new TicketInteractionNotification(
                interaction.Id,
                ticketResult.Id,
                ticketResult.Description,
                ticketResult.StatusTicket.Name,
                ticketResult.Category.Name,
                ticketResult.Subcategory.Name,
                ticketResult.Attendant.Id,
                ticketResult.Attendant.Name,
                ticketResult.Attendant.Email,
                ticketResult.Client.Name,
                ticketResult.Client.Email,
                interaction.Message,
                ticketResult.Attendant.Role,
                interaction.CreatedAt,
                ticketResult.CreatedAt,
                ticketResult.Interactions);

            await _mediator.Publish(ticket);

            return ResultViewModel<int>.Success(interaction.Id);
        }
    }
}
