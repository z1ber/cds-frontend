using Refit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CDS.Models;

namespace CDS.Services
{
    public class RestClientAPI: IRestClientAPI
    {
        private readonly IRestClientAPI _restClient;
        public RestClientAPI()
        {
            _restClient = RestService.For<IRestClientAPI>(RestEndPoints.BaseUrl);
        }
        public async Task <ICollection<Usuario>> GetAll()
        {
            return await _restClient.GetAll();
        }
        public async Task<Usuario> GetAll(int id)
        {
            return await _restClient.GetAll(id);
        }
    }
}
