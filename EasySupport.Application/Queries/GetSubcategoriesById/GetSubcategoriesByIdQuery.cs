using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetSubcategoriesById
{
    public class GetSubcategoriesByIdQuery : IRequest<ResultViewModel<SubcategoriesViewModel>>
    {
        public GetSubcategoriesByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
