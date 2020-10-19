using Homework20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework20.Interfaces
{
    public interface Ipers
    {
        IEnumerable<Character> GetPers();
        void AddPers(Character cahr);
    }
}
