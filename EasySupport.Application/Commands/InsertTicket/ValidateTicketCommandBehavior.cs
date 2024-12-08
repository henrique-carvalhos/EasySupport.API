using EasySupport.Application.Models;
using EasySupport.Infrastructure.Persistence;
using MediatR;

namespace EasySupport.Application.Commands.InsertTicket
{
    public class ValidateTicketCommandBehavior
        : IPipelineBehavior<InsertTicketCommand, ResultViewModel<int>>
    {
        private readonly EasySupportDbContext _context;
        public ValidateTicketCommandBehavior(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertTicketCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientExists = _context.Users.Any(c => c.Id == request.ClientId);
            var categoryExists = _context.Categories.Any(c => c.Id == request.CategoryId);
            var subCategoryExists = _context.Subcategories.Any(c => c.Id == request.SubcategoryId);
            var statusTicketExists = _context.StatusTickets.Any(c => c.Id == request.StatusTicketId);

            if(!clientExists ||  !categoryExists || !subCategoryExists || !statusTicketExists)
            {
                return ResultViewModel<int>.Error("Alguns desses identitificadores são inválidos: clientId, categoryId, subCategoryId ou statusTicketId");
            }

            return await next();
        }
    }
}
