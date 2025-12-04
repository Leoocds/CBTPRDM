using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProvaPRDM.Models;

namespace ProvaPRDM.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _db;

        public Database(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Livro>().Wait();
        }

        public Task<List<Livro>> GetLivrosAsync()
            => _db.Table<Livro>().ToListAsync();

        public Task<Livro> GetLivroAsync(int id)
            => _db.Table<Livro>().Where(i => i.Id == id).FirstOrDefaultAsync();

        public Task<int> SaveLivroAsync(Livro livro)
            => livro.Id == 0 ? _db.InsertAsync(livro) : _db.UpdateAsync(livro);

        public Task<int> DeleteLivroAsync(Livro livro)
            => _db.DeleteAsync(livro);
    }
}
