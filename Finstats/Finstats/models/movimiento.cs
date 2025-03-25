using System;
using System.Collections.Generic;

namespace FinanceApp.Models
{
    public class Movimiento
    {
        public long Id { get; set; }
        public required string Nombre { get; set; }
        public float Cant { get; set; }
        public DateTime Data { get; set; }

        public List<Category> Categories { get; set; } = new();
    }
}
