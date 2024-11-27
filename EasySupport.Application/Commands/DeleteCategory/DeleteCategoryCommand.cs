using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<ResultViewModel>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
