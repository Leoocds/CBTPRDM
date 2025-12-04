using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ProvaPRDM.Models
{
    public class Livro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Autor { get; set; }
        public string EmailAutor { get; set; }
        public string ISBN { get; set; }
    }
}
