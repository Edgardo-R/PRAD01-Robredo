using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRAD01.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(70)]
        public string nombre { get; set; }
        [MaxLength(70)]
        public string apellido { get; set; }
        [MaxLength(70)]
        public string correo { get; set; }
        public DateTime fecha_nac { get; set; }
        public string sexo { get; set; }
    }
}
