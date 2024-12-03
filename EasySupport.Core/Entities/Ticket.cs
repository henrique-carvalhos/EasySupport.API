using EasySupport.Core.Emums;

namespace EasySupport.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket(int clientId, int categoryId, int subcategoryId, int statusTicketId, Priority priority, string description)
            : base()
        {
            ClientId = clientId;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            StatusTicketId = statusTicketId;
            Priority = priority;
            Description = description;
            Interactions = new List<TicketInteraction>();
        }

        public int ClientId { get; private set; }
        public int CategoryId { get; private set; }
        public int SubcategoryId { get; private set; }
        public int StatusTicketId { get; private set; }
        public Priority Priority { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public StatusTicket StatusTicket { get; set; }
        public User Client { get; set; }//Adicionar uma para o Operador do tipo user, se basear no devfreala da nova versão
        public List<TicketInteraction> Interactions { get; set; }
    }
}
