using EasySupport.Core.Emums;

namespace EasySupport.Core.Entities
{
    public class Ticket : BaseEntity
    {
        public Ticket(int clientId, int? attendantId, int categoryId, int subcategoryId, int statusTicketId, int originServiceId, int? solutionTicketId,Priority priority, string description)
            : base()
        {
            ClientId = clientId;
            AttendantId = attendantId;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            StatusTicketId = statusTicketId;
            OriginServiceId = originServiceId;
            SolutionTicketId = solutionTicketId;
            Priority = priority;
            Description = description;
            Interactions = new List<TicketInteraction>();
        }

        public int ClientId { get; private set; }
        public User Client { get; set; }
        public int? AttendantId { get; private set; }
        public User Attendant { get; set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }
        public int SubcategoryId { get; private set; }
        public Subcategory Subcategory { get; set; }
        public int StatusTicketId { get; private set; }
        public StatusTicket StatusTicket { get; set; }
        public int OriginServiceId { get; private set; }
        public OriginService OriginService { get; set; }
        public int? SolutionTicketId { get; private set; }
        public SolutionTicket SolutionTicket { get; set; }
        public Priority Priority { get; private set; }
        public string Description { get; private set; }
        public List<TicketInteraction> Interactions { get; set; }


        public void Update(int clientId, int categoryId, int subcategoryId, int statusTicketId, int originService, Priority priority)
        {
            ClientId = clientId;
            CategoryId = categoryId;
            SubcategoryId = subcategoryId;
            StatusTicketId = statusTicketId;
            OriginServiceId = originService;
            Priority = priority;
        }

        public void AddAttendant(int attendantId)
        {
            AttendantId = attendantId;
        }

        public void UpdateStatus(int statusTicketId)
        {
            StatusTicketId = statusTicketId;
        }

        public void UpdateSolution(int solutionTicketId)
        {
            SolutionTicketId = solutionTicketId;
        }
    }
}
