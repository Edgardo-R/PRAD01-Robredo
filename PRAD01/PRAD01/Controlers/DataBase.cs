using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRAD01.Models;
using PRAD01.Controlers;
using System.Threading.Tasks;


namespace PRAD01.Controlers
{
    public static class DataBase
    {
        public static Task<List<Personas>> ObtenerListaPersonas()
        {
            return DB.dbconexion.Table<Personas>().ToListAsync();
        }
        public static Task<List<Sitios>> ObtenerListaSitios()
        {
            return DB.dbconexion.Table<Sitios>().ToListAsync();
        }
        public static Task<int> AddPersona(Personas persona)
        {
            if (persona.ID != 0)
            {
                return DB.dbconexion.UpdateAsync(persona);
            }
            else
            {
                return DB.dbconexion.InsertAsync(persona);
            }
        }
        public static Task<Personas> obtenerPersona(int pid)
        {
            return DB.dbconexion.Table<Personas>()
                .Where(i => i.ID == pid)
                .FirstOrDefaultAsync();
        }
        public static Task<int> DelPersona(Personas persona)
        {
            return DB.dbconexion.DeleteAsync(persona);
        }
    }
}
