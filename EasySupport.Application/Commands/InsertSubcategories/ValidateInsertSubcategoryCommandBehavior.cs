using EasySupport.Application.Models;
using EasySupport.Infrastructure.Persistence;
using MediatR;

namespace EasySupport.Application.Commands.InsertSubcategories
{
    public class ValidateInsertSubcategoryCommandBehavior
        : IPipelineBehavior<InsertSubcategoriesCommand, ResultViewModel<int>>
    {
        private readonly EasySupportDbContext _context;
        public ValidateInsertSubcategoryCommandBehavior(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertSubcategoriesCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var categoryExists =  _context.Categories.Any(c => c.Id == request.CategoryId);

            if (!categoryExists)
            {
                return ResultViewModel<int>.Error($"Categoria com identificador {request.CategoryId} é inválida");
            }

            return await next();
        }
    }
}
