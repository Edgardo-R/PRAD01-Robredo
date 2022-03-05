using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRAD01.Models;

namespace PRAD01.Controlers
{
    public static class DB
    {
        public static SQLiteAsyncConnection dbconexion;
        // Procedimiento Estatico
        public static void conexion(string dbpath)
        {
            dbconexion = new SQLiteAsyncConnection(dbpath);
            // Procedemos a crear las tablas de la base de datos
            dbconexion.CreateTableAsync<Personas>();
            dbconexion.CreateTableAsync<Sitios>();

        }
    }
} 
