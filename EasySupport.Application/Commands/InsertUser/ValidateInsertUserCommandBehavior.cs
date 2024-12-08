using EasySupport.Application.Models;
using EasySupport.Infrastructure.Persistence;
using MediatR;

namespace EasySupport.Application.Commands.InsertUser
{
    public class ValidateInsertUserCommandBehavior :
        IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly EasySupportDbContext _context;
        public ValidateInsertUserCommandBehavior(EasySupportDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var enterpriseExists = _context.Enterprises.Any(e => e.Id == request.EnterpriseId);
            var departmentExists = _context.Departments.Any(d => d.Id == request.DepartmentId);

            if(!enterpriseExists || !departmentExists)
            {
                return ResultViewModel<int>.Error("Departamento ou empresa são inválidos");
            }

            return await next();
        }
    }
}
