using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.UpdateStatusTicket
{
    public class UpdateStatusTicketCommandHandler : IRequestHandler<UpdateStatusTicketCommand, ResultViewModel>
    {
        private readonly IStatusTicketRepository _repository;
        public UpdateStatusTicketCommandHandler(IStatusTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateStatusTicketCommand request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.StatusTicketId);

            if(status is null)
            {
                return ResultViewModel.Error("Status do ticket não encotrado");
            }

            status.Update(request.Name);
            await _repository.UpdateAsync(status);

            return ResultViewModel.Success();
        }
    }
}
