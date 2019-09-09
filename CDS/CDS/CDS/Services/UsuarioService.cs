using CDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public class UsuarioService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Usuario>> GetProdutosAsync()
         
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/usuario";
                var response = await client.GetStringAsync(url);
                var user = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/usuario";
                var uri = new Uri(url);
                var data = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LoginUsuarioAsync(Usuario usuario)
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/login";
                var uri = new Uri(string.Format(url));
                var data = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(data, Encoding.UTF8, "application / json");
                //HttpResponseMessage response = null;
                var response = await client.PostAsync(uri, content);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            string url = "https://horario-cds.herokuapp.com/api/usuario/{0} ";
            var uri = new Uri(string.Format(url, usuario.idUsuario));
            var data = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(data, Encoding.UTF8, "application / json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error updating product");
            }
        }
        public async Task DeletUsuarioAsync(Usuario usuario)
        {
            string url = "https://horario-cds.herokuapp.com/api/usuario/{0} ";
            var uri = new Uri(string.Format(url, usuario.idUsuario));
            await client.DeleteAsync(uri);
        }
    }
}
