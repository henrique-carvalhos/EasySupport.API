using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateTicket
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, ResultViewModel>
    {
        private readonly ITicketRepository _repository;
        public UpdateTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.TicketId);

            if (ticket is null)
            {
                return ResultViewModel.Error("Ticket não encontrado");
            }

            ticket.Update(request.ClientId, request.CategoryId, request.SubcategoryId, request.StatusTicketId, request.OriginServiceId, request.Priority);
            await _repository.UpdateAsync(ticket);

            return ResultViewModel.Success();
        }
    }
}
