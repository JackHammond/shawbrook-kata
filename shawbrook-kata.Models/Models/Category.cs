using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Interfaces
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
