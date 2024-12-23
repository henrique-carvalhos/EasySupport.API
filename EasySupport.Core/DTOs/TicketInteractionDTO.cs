namespace EasySupport.Core.DTOs
{
    public class TicketInteractionDTO
    {
        public TicketInteractionDTO(int id, int ticketId, int attendantId, string attendantName, string role, string message, string statusTicket, string solutionTicket, DateTime createdAt)
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
    }
}
