using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vazar.Data.model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ovdje označavate da ID bude auto-increment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}