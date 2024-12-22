using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class TicketViewModel
    {
        public TicketViewModel(int id, bool isDeleted, int clientId, string nameClient, int categoryId, string nameCategory, int subcategoryId, string nameSubcategory, int statusTicketId, string nameStatusTicket,string originServiceName,int solutionTicketId, string solution ,string priority, string description, List<TicketInteraction> interactions)
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
            OriginServiceName = originServiceName;
            SolutionTicketId = solutionTicketId;
            Solution = solution;
            Priority = priority;
            Description = description;
            Interactions = interactions.Select(i => new TicketInteractionsViewModel(i.Id, i.Ticket.Id, i.Attendant.Id, i.Attendant.Name, i.Attendant.Role, i.Message, i.StatusTicket.Name, i.SolutionTicket.Name, i.CreatedAt)).ToList();
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
        public int SolutionTicketId { get; private set; }
        public string Solution { get; private set; }
        public string OriginServiceName { get; private set; }
        public string Priority { get; private set; }
        public string Description { get; private set; }
        public List<TicketInteractionsViewModel> Interactions { get; private set; }

        public static TicketViewModel FromEntity(Ticket ticket)
        => new(
            ticket.Id,
            ticket.IsDeleted,
            ticket.Client?.Id ?? 0,
            ticket.Client?.Name ?? "N/A",
            ticket.Category?.Id ?? 0,
            ticket.Category?.Name ?? "N/A",
            ticket.Subcategory?.Id ?? 0,
            ticket.Subcategory?.Name ?? "N/A",
            ticket.StatusTicket?.Id ?? 0,
            ticket.StatusTicket?.Name ?? "N/A",
            ticket.OriginService?.Name ?? "N/A",
            ticket.SolutionTicket?.Id ?? 0,
            ticket.SolutionTicket?.Name ?? "N/A",
            ticket.Priority.ToString(),
            ticket.Description,
            ticket.Interactions);
    }
}
