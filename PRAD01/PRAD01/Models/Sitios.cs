using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRAD01.Models
{
    public class Sitios
    {
        [PrimaryKey, AutoIncrement]
        public int IdFoto { get; set; }
        public string descripcion { get; set; }
        [MaxLength(100)]
        public double longitud { get; set; }
        public byte[] foto { get; set; }
        public double latitud { get; set; }
        public DateTime fecha { get; set; }

    }
}
