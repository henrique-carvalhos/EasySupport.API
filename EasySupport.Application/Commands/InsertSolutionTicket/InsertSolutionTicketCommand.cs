using EasySupport.Application.Models;
using EasySupport.Core.Entities;
using MediatR;

namespace EasySupport.Application.Commands.InsertSolutionTicket
{
    public class InsertSolutionTicketCommand : IRequest<ResultViewModel<int>>
    {
        public string Name { get; set; }

        public SolutionTicket ToEntity()
            => new(Name);
    }
}
