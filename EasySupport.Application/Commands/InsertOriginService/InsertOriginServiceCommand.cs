using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertOriginService
{
    public class InsertOriginServiceCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public OriginService ToEntity()
            => new(Name);
    }
}
