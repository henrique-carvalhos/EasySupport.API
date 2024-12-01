using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertStatusTicket
{
    public class InsertStatusTicketCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public StatusTicket ToEntity()
            => new(Name);
    }
}
