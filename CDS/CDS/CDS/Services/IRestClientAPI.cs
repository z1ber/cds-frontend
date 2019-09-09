using CDS.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Services
{
    public interface IRestClientAPI
    {
        [Get("/usuario")]
        Task<ICollection<Usuario>> GetAll();

        [Get("/usuario/{id} ")] 
        Task<Usuario> GetAll(int id);

        // [Post ("/ posts")]
        // Task AddPost (User post);
    }
}
