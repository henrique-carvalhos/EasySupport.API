using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class SolutionViewModel
    {
        public SolutionViewModel(int id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public static SolutionViewModel FromEntity(SolutionTicket solution)
            => new(solution.Id, solution.Name, solution.IsDeleted);
    }
}
