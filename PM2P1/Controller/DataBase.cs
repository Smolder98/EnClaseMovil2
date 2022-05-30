using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM2P1.Models;
using SQLite;

namespace PM2P1.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;

        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Creacion de las tablas de la base de datos

            dbase.CreateTableAsync<Empleado>(); //Creando la tabla empleado

        }

        #region OperacionesEmpleado
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateEmpleado(Empleado emp)
        {
            if(emp.id != 0)
            {
                return dbase.UpdateAsync(emp);
            }
            else
            {
                return dbase.InsertAsync(emp);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Empleado>> getListEmpleado()
        {
            return dbase.Table<Empleado>().ToListAsync();
        }

        public Task<Empleado> getEmpleado(int id)
        {
            return dbase.Table<Empleado>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteEmpleado(Empleado emp)
        {
            return dbase.DeleteAsync(emp);
        }

        #endregion OperacionesEmpleado

    }
}
