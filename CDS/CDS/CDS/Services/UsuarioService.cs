using CDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public class UsuarioService
    {
        HttpClient client = new HttpClient();
        public async Task<Response> GetAll<T>(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = "Error de respuesta del servidor"
                    };
                }
                //string url = "https://horario-cds.herokuapp.com/api/usuario";
                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<T>>(result);
                return new Response
                {
                    isSuccess = true,
                    Result = list
                };
            }
            catch (System.Exception)
            {
                return new Response
                {
                    isSuccess = false,
                    Message = "Error al cargar los datos"
                };
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

        public async Task<Response> LoginUsuarioAsync<T>(T model)
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/login";
                //var uri = new Uri(string.Format(url));
                string request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url,content);
                
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = "Error de respuesta del servidor"
                    };
                }
                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<Usuario>>(result);
                var obj = list[0];
                return new Response
                {
                    isSuccess = true,
                    Result = Convert.ToString(obj.idRol)
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    isSuccess = false,
                    Message = ex.ToString(),
                };
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
