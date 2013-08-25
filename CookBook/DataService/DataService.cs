using CookBook.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DataService
{
    public class DataService
    {
        public static Task<ObservableCollection<Tipo>> LoadTipos()
        {
            string uriStringTipos = "http://oficinadamoto.com.br/receitas/index.php/site/getTipos";

            var tcs = new TaskCompletionSource<ObservableCollection<Tipo>>();
            var wc = new HttpClient();
            var ret = wc.GetStringAsync(uriStringTipos);
            tcs.TrySetResult(JSONToTipos(ret.Result));

            return tcs.Task;
        }

        private static ObservableCollection<Tipo> JSONToTipos(string result)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(result);
            var ListTipos = new ObservableCollection<Tipo>();

            for (var i = 0; i < results.Count; i++)
            {
                Tipo tp = new Tipo(results[i]);
                ListTipos.Add(tp);
            }

            return ListTipos;
        }

        public static Task<ObservableCollection<Categoria>> LoadCategorias()
        {
            string uriStringCategorias = "http://oficinadamoto.com.br/receitas/index.php/site/getCategorias";

            var tcs = new TaskCompletionSource<ObservableCollection<Categoria>>();
            var wc = new HttpClient();
            var ret = wc.GetStringAsync(uriStringCategorias);
            tcs.TrySetResult(JSONToCategorias(ret.Result));

            return tcs.Task;
        }

        private static ObservableCollection<Categoria> JSONToCategorias(string result)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(result);
            var ListCategorias = new ObservableCollection<Categoria>();

            for (var i = 0; i < results.Count; i++)
            {
                Categoria ct = new Categoria(results[i]);
                ListCategorias.Add(ct);
            }

            return ListCategorias;
        }

        public static Task<ObservableCollection<Receita>> LoadReceitas()
        {
            string uriStringReceitas = "http://oficinadamoto.com.br/receitas/index.php/site/getReceitas";

            var tcs = new TaskCompletionSource<ObservableCollection<Receita>>();
            var wc = new HttpClient();
            var ret = wc.GetStringAsync(uriStringReceitas);
            tcs.TrySetResult(JSONToLoadReceitas(ret.Result));

            return tcs.Task;
        }

        private static ObservableCollection<Receita> JSONToLoadReceitas(string result)
        {
            dynamic results = JsonConvert.DeserializeObject<dynamic>(result);
            var ListCategorias = new ObservableCollection<Receita>();

            for (var i = 0; i < results.Count; i++)
            {
                Receita ct = new Receita(results[i]);
                ListCategorias.Add(ct);
            }

            return ListCategorias;
        }
    }
}
