using EasySupport.Core.Emums;

namespace EasySupport.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket(int clientId, int categoryId, int subcategoryId, int statusTicketId, int prioridadeId, Priority priority, string description)
        {
            ClientId = clientId;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            StatusTicketId = statusTicketId;
            PrioridadeId = prioridadeId;
            Priority = priority;
            Description = description;
        }

        public int ClientId { get; private set; }
        public int CategoryId { get; private set; }
        public int SubcategoryId { get; private set; }
        public int StatusTicketId { get; private set; }
        public int PrioridadeId { get; private set; }
        public Priority Priority { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public StatusTicket StatusTicket { get; set; }
        public User Client { get; set; }
        public List<TicketInteraction> Interactions { get; set; }
    }
}
