using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertStatusTicket
{
    public class InsertStatusTicketCommandHandler : IRequestHandler<InsertStatusTicketCommand, ResultViewModel<int>>
    {
        private readonly IStatusTicketRepository _repository;
        public InsertStatusTicketCommandHandler(IStatusTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertStatusTicketCommand request, CancellationToken cancellationToken)
        {
            var status = request.ToEntity();

            await _repository.AddAsync(status);

            return ResultViewModel<int>.Success(status.Id);
        }
    }
}
