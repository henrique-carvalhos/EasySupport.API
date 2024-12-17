using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class TicketInteractionsViewModel
    {
        public TicketInteractionsViewModel(int id, int ticketId, int attendantId, string attendantName, string role, string message, string statusTicket, string solutionTicket, DateTime createdAt)
        {
            Id = id;
            TicketId = ticketId;
            AttendantId = attendantId;
            AttendantName = attendantName;
            Role = role;
            Message = message;
            StatusTicket = statusTicket;
            SolutionTicket = solutionTicket;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public int AttendantId { get; private set; }
        public string AttendantName { get; set; }
        public string Role { get; set; }
        public string Message { get; private set; }
        public string StatusTicket { get; set; }
        public string SolutionTicket { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public static TicketInteractionsViewModel FromEntity(TicketInteraction interaction)
            => new(interaction.Id, interaction.Ticket.Id, interaction.Attendant.Id, interaction.Attendant.Name, interaction.Attendant.Role, interaction.Message, interaction.StatusTicket.Name, interaction.SolutionTicket.Name, interaction.CreatedAt);

    }
}
