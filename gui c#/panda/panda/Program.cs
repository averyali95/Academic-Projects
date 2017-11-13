using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panda
{
    public class Dude
    {
        public string name;
        public Dude(string n) { name = n; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dude d1 = new Dude("john");
            Dude d2 = new Dude("john");
            Dude d3 = d1;
            Console.WriteLine(d1 == d2); //false the two adresses points to two different places.
            Console.WriteLine(d1 == d3); //true d3 points to the position of d1
        }
    }
}
