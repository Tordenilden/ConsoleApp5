using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    /// <summary>
    /// This class is coded , so we can Reflect on it (using the Meta data)
    /// </summary>
    public class Hero // Type defined by us!!
    {
        public int Id { get; set; }
        // no dates!! plz not today - ask me later if needed
        public string Name { get; set; } // [1]
        public string Agility { get; set; }
        public string Intelligens { get; set; }
        public Hero()
        {
            
        }
         ~Hero() // this is Dispose() - just our own version of it...
        {
            // if there is a handle to db context ... we can "Dispose(), close() it"
        }

    }
}
