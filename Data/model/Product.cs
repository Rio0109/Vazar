using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vazar.Data.model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ovdje označavate da ID bude auto-increment
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price  { get; set; }
        public int Produced { get; set; }
        public string Model { get; set; }
    }
}
