using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertSubcategories
{
    public class InsertSubcategoriesCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Subcategory ToEntity()
            => new(Name, CategoryId);
    }
}
