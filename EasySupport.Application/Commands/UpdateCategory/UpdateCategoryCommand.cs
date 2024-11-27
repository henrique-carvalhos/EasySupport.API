using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ResultViewModel>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
