namespace EasySupport.Core.Entities
{
    public class TicketInteraction
    {
        public TicketInteraction(int ticketId,int attendantId, int statusTicketId,string message)
        {
            TicketId = ticketId;
            AttendantId = attendantId;
            StatusTicktId = statusTicketId;
            Message = message;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; set; }
        public int AttendantId { get; private set; }
        public User Attendant { get; set; }
        public int StatusTicktId { get; private set; }
        public StatusTicket StatusTicket { get; set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
