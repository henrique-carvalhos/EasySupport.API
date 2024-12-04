using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicket
{
    public class InsertTicketCommandHandler : IRequestHandler<InsertTicketCommand, ResultViewModel<int>>
    {
        private readonly ITicketRepository _repository;
        public InsertTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = request.ToEntity();

            await _repository.AddAsync(ticket);

            return ResultViewModel<int>.Success(ticket.Id);
        }
    }
}
