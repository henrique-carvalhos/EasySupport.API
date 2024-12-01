using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class StatusTicketViewModel
    {
        public StatusTicketViewModel(int id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public static StatusTicketViewModel FromEntity(StatusTicket status)
            => new(status.Id, status.Name, status.IsDeleted);
    }
}
