using Homework20.Interfaces;
using Homework20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Homework20.Data
{
    public class PersApi : Ipers
    {
        private HttpClient client;

        public PersApi(HttpClient httpClient)
        {
            client = httpClient;
        }

        public void AddPers(Character cahr)
        {
            
        }

        public IEnumerable<Character> GetPers()
        {
            List<Character> Chara = new List<Character>();
            return Chara;
        }
    }
}
