using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetAllEnterprise
{
    public class GetAllEnterpriseQuery : IRequest<ResultViewModel<List<EnterpriseViewModel>>>
    {
        public GetAllEnterpriseQuery(string search)
        {
            Search = search;
        }

        public string Search { get; set; }
    }
}
