using CDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public class HorarioService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Horario>> GetHorariosAsync()

        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/horario";
                var response = await client.GetStringAsync(url);
                var horario = JsonConvert.DeserializeObject<List<Horario>>(response);
                return horario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Horario>> GetHorariosDiaAsync(string dia, int grupo)

        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/horarios/" + dia+"/"+grupo;
                var response = await client.GetStringAsync(url);
                var horario = JsonConvert.DeserializeObject<List<Horario>>(response);
                return horario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddHorarioAsync(Horario horario)
        {
            try
            {
                string url = " https://horario-cds.herokuapp.com/api/horario";
                var uri = new Uri(url);
                var data = JsonConvert.SerializeObject(horario);
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


        public async Task UpdateHorarioAsync(Horario horario)
        {
            string url = "https://horario-cds.herokuapp.com/api/horario/{0} ";
            var uri = new Uri(string.Format(url, horario.nombreMateria));
            var data = JsonConvert.SerializeObject(horario);
            var content = new StringContent(data, Encoding.UTF8, "application / json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error updating product");
            }
        }
        public async Task DeleteHorarioAsync(Docente docente)
        {
            string url = "https://horario-cds.herokuapp.com/api/horario/{0} ";
            var uri = new Uri(string.Format(url, docente.idDocente));
            await client.DeleteAsync(uri);
        }
    }
}
