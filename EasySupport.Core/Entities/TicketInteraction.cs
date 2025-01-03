﻿namespace EasySupport.Core.Entities
{
    public class TicketInteraction
    {
        public TicketInteraction(int ticketId,int attendantId, int statusTicketId,int? solutionTicketId,string message)
        {
            TicketId = ticketId;
            AttendantId = attendantId;
            StatusTicketId = statusTicketId;
            SolutionTicketId = solutionTicketId;
            Message = message;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public Ticket Ticket { get; set; }
        public int AttendantId { get; private set; }
        public User Attendant { get; set; }
        public int StatusTicketId { get; private set; }
        public StatusTicket StatusTicket { get; set; }
        public int? SolutionTicketId { get; private set; }
        public SolutionTicket SolutionTicket { get; set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
