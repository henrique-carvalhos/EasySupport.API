using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetEntreprise
{
    public class GetEntrepriseByIdQuery : IRequest<ResultViewModel<EnterpriseViewModel>>
    {
        public GetEntrepriseByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
