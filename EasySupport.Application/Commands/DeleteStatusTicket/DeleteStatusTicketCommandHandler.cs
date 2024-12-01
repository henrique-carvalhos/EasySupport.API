using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.DeleteStatusTicket
{
    public class DeleteStatusTicketCommandHandler : IRequestHandler<DeleteStatusTicketCommand, ResultViewModel>
    {
        private readonly IStatusTicketRepository _repository;
        public DeleteStatusTicketCommandHandler(IStatusTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteStatusTicketCommand request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.Id);

            if (status is null)
            {
                return ResultViewModel.Error("Status do ticket não encontrado");
            }

            status.SetAsDeleted();
            await _repository.UpdateAsync(status);

            return ResultViewModel.Success();   
        }
    }
}
