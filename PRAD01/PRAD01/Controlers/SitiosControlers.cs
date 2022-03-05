using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRAD01.Models;
using PRAD01.Controlers;
using System.Threading.Tasks;


namespace PRAD01.Controlers
{
    public class SitiosControlers
    {
        public SitiosControlers()
        {
        }
        //procedimientos
        // retorna todas las filas de la tabla personas
        public Task<List<Sitios>> ObtenerListaSitios()
        {
            return DB.dbconexion.Table<Sitios>().ToListAsync();
        }
        //operaciones crud-create, read, update, delete
        //insert, select, update, delete
        //create-update
        public Task<int> AddSitios (Sitios sitio)
        {
            if (sitio.IdFoto != 0)
            {
                //ejecutamos el procedimiento de actualizacion update
                return DB.dbconexion.UpdateAsync(sitio);
            }
            else
            {
                //ejecutamos el procedimiento de inserccion de una persona
                return DB.dbconexion.InsertAsync(sitio);
            }
        }
        // obtenemos por el id un registro de un persona
        public Task<Sitios> obtenerSitio(int pid)
        {
            return DB.dbconexion.Table<Sitios>()
                .Where(i => i.IdFoto == pid)
                .FirstOrDefaultAsync();
        }
        // eliminamos el registro de una persona
        public Task<int> DelSitio(Sitios sitio)
        {
            return DB.dbconexion.DeleteAsync(sitio);
        }
    }
}
