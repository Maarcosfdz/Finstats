using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Movimiento
    {
        [Key]
        public long Id { get; set; }
        public required string Nombre { get; set; }
        public float Cant { get; set; }
        public DateTime Data { get; set; }
        public int IdentGasto { get; set; }

        public List<Category> Categories { get; set; } = new();
    }
}
