using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence_example
{
    public class Asset
    {
        public string Name;
        public decimal PurchasePrice, CurrentPrice;
    }

    public class House : Asset 
    {
        public decimal Mortage;

        public decimal getMortage
        { 
            get{ return Mortage; } 
        }
    }
    public class Stock : Asset
    {
        public long SharesOwned;
       
        public long getShares
        {
            get { return SharesOwned; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock msft = new Stock() 
            {
                Name = "msft",
                PurchasePrice = 20,
                CurrentPrice = 30,
                SharesOwned = 50
            };
            House mansion = new House() 
            { 
                Name = "House", 
                PurchasePrice = 1000000, 
                CurrentPrice = 30000000, 
                Mortage = 2330 
            };

            Console.WriteLine(msft.Name);
            Console.WriteLine("$"+msft.PurchasePrice);
            Console.WriteLine(mansion.Name);
            Console.WriteLine("$"+mansion.PurchasePrice);
            Console.WriteLine("Mircosoft Shares: "+ msft.getShares);
            Console.WriteLine("Mansion mortage: " +mansion.getMortage);

        }
    }
}
