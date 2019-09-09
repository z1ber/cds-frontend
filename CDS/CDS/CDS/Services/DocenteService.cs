using CDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public class DocenteService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Docente>> GetDocentesAsync()

        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/docente";
                var response = await client.GetStringAsync(url);
                var docente = JsonConvert.DeserializeObject<List<Docente>>(response);
                return docente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
        }
    }
}
