using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicketInteraction
{
    public class InsertTicketInteractionCommandHandler : IRequestHandler<InsertTicketInteractionCommand, ResultViewModel<int>>
    {
        private readonly ITicketInteractionRepository _repository;
        public InsertTicketInteractionCommandHandler(ITicketInteractionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketInteractionCommand request, CancellationToken cancellationToken)
        {
            var interaction = request.ToEntity();

            await _repository.AddAsync(interaction);

            return ResultViewModel<int>.Success(interaction.Id);
        }
    }
}
