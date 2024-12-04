using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class TicketViewModel
    {
        public TicketViewModel(int id, bool isDeleted, int clientId, string nameClient, int categoryId, string nameCategory, int subcategoryId, string nameSubcategory, int statusTicketId, string nameStatusTicket, string priority, string description, List<TicketInteraction> interactions)
        {
            Id = id;
            IsDeleted = isDeleted;
            ClientId = clientId;
            NameClient = nameClient;
            CategoryId = categoryId;
            NameCategory = nameCategory;
            SubcategoryId = subcategoryId;
            NameSubcategory = nameSubcategory;
            StatusTicketId = statusTicketId;
            NameStatusTicket = nameStatusTicket;
            Priority = priority;
            Description = description;
            Interactions = interactions.Select(i => new TicketInteractionsViewModel(i.Id, i.Ticket.Id, i.Attendant.Id, i.Attendant.Name, i.Message, i.CreatedAt)).ToList();
        }

        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public int ClientId { get; private set; }
        public string NameClient { get; private set; }
        public int CategoryId { get; private set; }
        public string NameCategory { get; private set; }
        public int SubcategoryId { get; private set; }
        public string NameSubcategory { get; private set; }
        public int StatusTicketId { get; private set; }
        public string NameStatusTicket { get; private set; }
        public string Priority { get; private set; }
        public string Description { get; private set; }
        public List<TicketInteractionsViewModel> Interactions { get; private set; }

        public static TicketViewModel FromEntity(Ticket ticket)
        => new(
            ticket.Id,
            ticket.IsDeleted,
            ticket.Client.Id,
            ticket.Client.Name,
            ticket.Category.Id,
            ticket.Category.Name,
            ticket.Subcategory.Id,
            ticket.Subcategory.Name,
            ticket.StatusTicket.Id,
            ticket.StatusTicket.Name,
            ticket.Priority.ToString(),
            ticket.Description,
            ticket.Interactions);
    }
}
