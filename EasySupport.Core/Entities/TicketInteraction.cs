namespace EasySupport.Core.Entities
{
    public class TicketInteraction
    {
        public TicketInteraction(int ticketId,int userId,string message, DateTime createdAt)
        {
            TicketId = ticketId;
            UserId = userId;
            Message = message;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; set; }
        public int UserId { get; private set; }
        public User User { get; set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
