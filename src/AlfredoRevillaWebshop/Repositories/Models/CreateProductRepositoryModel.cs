namespace AlfredoRevillaWebshop.Repositories.Models
{
    public class CreateProductRepositoryModel
    {
        public string MPN { get; internal set; }
        public string Title { get; internal set; }
        public decimal Price { get; internal set; }
    }
}