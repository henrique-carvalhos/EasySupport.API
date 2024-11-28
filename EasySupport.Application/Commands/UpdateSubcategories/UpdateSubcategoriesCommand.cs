using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateSubcategories
{
    public class UpdateSubcategoriesCommand : IRequest<ResultViewModel>
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
