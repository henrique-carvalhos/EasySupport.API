using MediatR;

namespace EasySupport.Infrastructure.Notifications.TicketCreated
{
    public class TicketCreatedNotification : INotification
    {
        public TicketCreatedNotification(int id, DateTime createdAt, string nameClient, string senderEmail, string nameCategory, string nameSubcategory, string description)
        {
            Id = id;
            CreatedAt = createdAt;
            NameClient = nameClient;
            SenderEmail = senderEmail;
            NameCategory = nameCategory;
            NameSubcategory = nameSubcategory;
            Description = description;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string NameClient { get; private set; }
        public string SenderEmail { get; private set; }
        public string NameCategory { get; private set; }
        public string NameSubcategory { get; private set; }
        public string Description { get; private set; }
    }
}
