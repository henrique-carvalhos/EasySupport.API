using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.UpdateSolutionTicket
{
    public class UpdateSolutionTicketCommand : IRequest<ResultViewModel>
    {
        public int SolutionTicketId { get; set; }
        public string Name { get; set; }
    }
}
