namespace EasySupport.Core.Entities
{
    public class TicketInteraction
    {
        public TicketInteraction(int ticketId,int attendantId, string message, DateTime createdAt)
        {
            TicketId = ticketId;
            AttendantId = attendantId;
            Message = message;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; set; }
        public int AttendantId { get; private set; }
        public User Attendant { get; set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
