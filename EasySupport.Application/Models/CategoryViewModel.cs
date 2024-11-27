using EasySupport.Core.Entities;

namespace EasySupport.Application.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel(int id, string name, bool isDeleted, List<Subcategory> subcategories)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
            Subcategories = new List<Subcategory>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Subcategory> Subcategories { get; private set; }

        public static CategoryViewModel FromEntity(Category category)
        {
            var subcategories = category.Subcategories.ToList();

            return new CategoryViewModel(category.Id, category.Name, category.IsDeleted, subcategories);
        }
    }
}
