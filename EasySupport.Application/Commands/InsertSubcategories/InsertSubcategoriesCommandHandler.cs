using EasySupport.Application.Models;
using EasySupport.Core.Repositories;
using MediatR;

namespace EasySupport.Application.Commands.InsertSubcategories
{
    public class InsertSubcategoriesCommandHandler : IRequestHandler<InsertSubcategoriesCommand, ResultViewModel<int>>
    {
        private readonly ISubcategoriesRepository _repository;
        public InsertSubcategoriesCommandHandler(ISubcategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSubcategoriesCommand request, CancellationToken cancellationToken)
        {
            var subcategory = request.ToEntity();

            await _repository.AddAsync(subcategory);

            return ResultViewModel<int>.Success(subcategory.Id);
        }
    }
}
