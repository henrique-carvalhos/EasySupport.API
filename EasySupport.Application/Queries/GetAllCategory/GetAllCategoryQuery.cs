using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<ResultViewModel<List<CategoryViewModel>>>
    {
        public GetAllCategoryQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
