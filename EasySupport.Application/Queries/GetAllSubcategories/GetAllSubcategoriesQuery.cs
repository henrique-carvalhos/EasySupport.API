using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllSubcategories
{
    public class GetAllSubcategoriesQuery : IRequest<ResultViewModel<List<SubcategoriesViewModel>>>
    {
        public GetAllSubcategoriesQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
