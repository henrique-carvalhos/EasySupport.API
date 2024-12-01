using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateOriginService
{
    public class UpdateOriginServiceCommand : IRequest<ResultViewModel>
    {
        public int OriginServeceId { get; set; }
        public string Name { get; set; }
    }
}
