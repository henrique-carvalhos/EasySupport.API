using EasySupport.Application.Models;
using MediatR;

namespace EasySupport.Application.Commands.DeleteSolutionTicket
{
    public class DeleteSolutionTicketCommand : IRequest<ResultViewModel>
    {
        public DeleteSolutionTicketCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
