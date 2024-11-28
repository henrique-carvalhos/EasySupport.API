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
            Subcategories = subcategories.Select(s => new SubcategoriesViewModel(s.Id, s.Name, s.IsDeleted, s.Category.Id, s.Category.Name)).ToList() ;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<SubcategoriesViewModel> Subcategories { get; private set; }

        public static CategoryViewModel FromEntity(Category category)
            => new (category.Id, category.Name, category.IsDeleted, category.Subcategories);
    }
}
