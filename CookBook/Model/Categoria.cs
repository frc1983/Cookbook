using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Model
{
    public class Categoria
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public string Nome { get; set; }

        public Categoria(dynamic results)
        {
            this.Id = Convert.ToInt32(results["id"].Value);
            this.IdTipo = Convert.ToInt32(results["id_tipo"].Value);
            this.Nome = results["nome"].Value;
        }
    }
}
