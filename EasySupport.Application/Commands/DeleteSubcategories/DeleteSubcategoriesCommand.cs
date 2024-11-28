using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteSubcategories
{
    public class DeleteSubcategoriesCommand : IRequest<ResultViewModel>
    {
        public DeleteSubcategoriesCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
