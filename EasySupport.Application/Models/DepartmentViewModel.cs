using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel(int id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public static DepartmentViewModel FromEntity(Department department)
            => new(department.Id, department.Name, department.IsDeleted);
    }
}
