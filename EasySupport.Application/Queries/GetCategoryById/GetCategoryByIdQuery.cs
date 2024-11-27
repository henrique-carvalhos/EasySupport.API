using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<ResultViewModel<CategoryViewModel>>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
