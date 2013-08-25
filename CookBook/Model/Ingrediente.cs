using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Model
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Ingrediente(dynamic results)
        {
            this.Id = Convert.ToInt32(results["id"].Value);
            this.Nome = results["ingrediente"].Value;
        }
    }
}
