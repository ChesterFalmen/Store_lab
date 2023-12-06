namespace Store.Data.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string? Model { get; set; }    
        public float Price { get; set; }
        public int Count { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
