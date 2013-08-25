using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Model
{
    public class Receita
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string Nome { get; set; }
        public string Rendimento { get; set; }
        public string Calorias { get; set; }
        public string TempoPreparo { get; set; }
        public string ModoPreparo { get; set; }
        public string ImageUrl { get; set; }

        public Receita(dynamic results)
        {
            this.Id = Convert.ToInt32(results["id"].Value);
            this.IdCategoria = Convert.ToInt32(results["id_categoria"].Value);

            Ingredientes = new List<Ingrediente>();
            foreach (dynamic ing in results["ingredientes"])
                Ingredientes.Add(new Ingrediente(ing));

            this.Nome = results["nome"].Value;
            this.Rendimento = results["rendimento"].Value;
            this.Calorias = results["calorias"].Value;
            this.TempoPreparo = results["tempo_preparo"].Value;
            this.ModoPreparo = results["modo_preparo"].Value;
            this.ImageUrl = results["image_url"].Value;
        }
    }
}
