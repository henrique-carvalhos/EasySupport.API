using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Queries.GetOriginServiceById
{
    public class GetOriginServiceByIdQuery : IRequest<ResultViewModel<OriginServiceViewModel>>
    {
        public GetOriginServiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
