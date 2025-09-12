namespace TaskDataBase.Models.ViewModel
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public float? Price { get; set; }
        public List<GetCategoryViewModel> Categories { get; set; }
    }
}
