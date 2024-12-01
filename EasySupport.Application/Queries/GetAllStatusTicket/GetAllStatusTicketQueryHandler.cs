using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Queries.GetAllStatusTicket
{
    public class GetAllStatusTicketQueryHandler : IRequestHandler<GetAllStatusTicketQuery, ResultViewModel<List<StatusTicketViewModel>>>
    {
        private readonly IStatusTicketRepository _repository;
        public GetAllStatusTicketQueryHandler(IStatusTicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<StatusTicketViewModel>>> Handle(GetAllStatusTicketQuery request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetAllAsync(request.Search);

            var model = status.Select(StatusTicketViewModel.FromEntity).ToList();

            return ResultViewModel<List<StatusTicketViewModel>>.Success(model);
        }
    }
}
