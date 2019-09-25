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
    public class DocenteService
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
                //string url = "https://horario-cds.herokuapp.com/api/docente";
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

        /*
        public async Task AddDocenteAsync(Docente docente)
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/docente";
                var uri = new Uri(url);
                var data = JsonConvert.SerializeObject(docente);
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

        
        public async Task UpdateDocenteAsync(Docente docente)
        {
            string url = "https://horario-cds.herokuapp.com/api/docente/{0} ";
            var uri = new Uri(string.Format(url, docente.idDocente));
            var data = JsonConvert.SerializeObject(docente);
            var content = new StringContent(data, Encoding.UTF8, "application / json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error updating product");
            }
        }
        public async Task DeleteDocenteAsync(Docente docente)
        {
            string url = "https://horario-cds.herokuapp.com/api/docente/{0} ";
            var uri = new Uri(string.Format(url, docente.idDocente));
            await client.DeleteAsync(uri);
        }*/
    }
}
