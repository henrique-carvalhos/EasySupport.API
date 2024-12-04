using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteTicket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, ResultViewModel>
    {
        private readonly ITicketRepository _repository;
        public DeleteTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.Id);

            if (ticket is null)
            {
                return ResultViewModel.Error("Ticket não encontrado");
            }

            ticket.SetAsDeleted();
            await _repository.UpdateAsync(ticket);

            return ResultViewModel.Success();
        }
    }
}
