using PM0220242P.Models;
using SQLite;

namespace PM0220242P.Controllers
{
    public class PersonasController
    {
        readonly SQLiteAsyncConnection _connection;

        public PersonasController()
        {
            SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
               //SQLiteOpenFlags.ReadOnly |
               SQLiteOpenFlags.Create |
               SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBPerson.db3"), extensiones);
            _connection.CreateTableAsync<Personas>();
        }

        // CRUD METHODS


        //Create //Update
        public async Task<int> StorePerson(Personas personas)
        {
            if (personas.Id == 0)
            {
                return await _connection.InsertAsync(personas);
            }
            else
            {
                return await _connection.UpdateAsync(personas);
            }
        }

        //Read
        public async Task<List<Personas>> GetListPersons()
        {
            return await _connection.Table<Personas>().ToListAsync();
        }

        public async Task<Personas> GetPerson(int id)
        {
            return await _connection.Table<Personas>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Delete
        public async Task<int> DeletePerson(Personas person)
        {
            return await _connection.DeleteAsync(person);
        }
    }
}
