using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Animal
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        //public Especie? Especie { get; set; }

        public int? EspecieId { get; set; }
    }
}
