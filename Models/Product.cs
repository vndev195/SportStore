using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Models{
    public class Product {
        public long? ProductId { get; set; }
        public string Name { get; set; } = String.Empty;  
        public string Description { get; set; } = String.Empty;
        [Column(TypeName = "decimal(8,2)")] //For database
        public decimal Price { get; set; }
        public string Category { get; set; } = String.Empty;
    }
}