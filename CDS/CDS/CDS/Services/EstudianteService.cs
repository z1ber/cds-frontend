using CDS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public class EstudianteService
    {
        HttpClient client = new HttpClient();
        public async Task<List<Estudiante>> GetEstudiantesAsync()

        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/estudiante";
                var response = await client.GetStringAsync(url);
                var estudiante = JsonConvert.DeserializeObject<List<Estudiante>>(response);
                return estudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Estudiante>> GetEstudianteGrupoAsync(int grupo)

        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/estudiantes/" + grupo;
                var response = await client.GetStringAsync(url);
                var estudiante = JsonConvert.DeserializeObject<List<Estudiante>>(response);
                return estudiante;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddEstudianteAsync(Estudiante estudiante)
        {
            try
            {
                string url = "https://horario-cds.herokuapp.com/api/estudiante";
                var uri = new Uri(url);
                var data = JsonConvert.SerializeObject(estudiante);
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


        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            string url = "https://horario-cds.herokuapp.com/api/estudiante/{0} ";
            var uri = new Uri(string.Format(url, estudiante.idEstudiante));
            var data = JsonConvert.SerializeObject(estudiante);
            var content = new StringContent(data, Encoding.UTF8, "application / json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error actualizando estudiante");
            }
        }
        public async Task DeleteDocenteAsync(Estudiante estudiante)
        {
            string url = " https://horario-cds.herokuapp.com/api/estudiante/{0} ";
            var uri = new Uri(string.Format(url, estudiante.idEstudiante));
            await client.DeleteAsync(uri);
        }
    }
}
