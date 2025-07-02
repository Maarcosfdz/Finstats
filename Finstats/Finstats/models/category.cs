using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Category
    {
        [Key]
        public required string Nombre { get; set; }
        public int IdentGasto { get; set; }

        // Propiedad de navegación para EF Core
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
