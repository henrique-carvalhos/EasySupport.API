using MediatR;

namespace EasySupport.Application.Notification.TicketInteractionCreated
{
    public class TicketInteractionNotification : INotification
    {
        public TicketInteractionNotification(int id, int ticketId, string description,string status, string nameCategory, string nameSubcategory, int attendantId, string attendantName, 
            string attendantSendEmail, string clientName,string clientSendEmail,string message,string role, DateTime createdAt, DateTime ticketCreatedAt)
        {
            Id = id;
            TicketId = ticketId;
            Description = description;
            Status = status;
            NameCategory = nameCategory;
            NameSubcategory = nameSubcategory;
            AttendantId = attendantId;
            AttendantName = attendantName;
            AttendantSendEmail = attendantSendEmail;
            ClientName = clientName;
            ClientSendEmail = clientSendEmail;
            Message = message;
            Role = role;
            CreatedAt = createdAt;
            TicketCreatedAt = ticketCreatedAt;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public string NameCategory { get; private set; }
        public string NameSubcategory { get; private set; }
        public int AttendantId { get; private set; }
        public string AttendantName { get; private set; }
        public string AttendantSendEmail { get; private set; }
        public string ClientName { get; private set; }
        public string ClientSendEmail { get; private set; }
        public string Message { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime TicketCreatedAt { get; private set; }
    }
}
