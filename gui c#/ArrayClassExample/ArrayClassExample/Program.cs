using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayClassExample
{
    public class Stock
    {
        String symbol;
        decimal purchasePrice, currentPrice;
        long sharesOwned;

        public Stock(string symbol, decimal purchasePrice, long sharesOwned)
        {
            this.symbol = symbol;
            this.purchasePrice = currentPrice = purchasePrice;
            this.sharesOwned = sharesOwned;
        }
        // Methods
        public string getSymbol { get { return symbol; } }
        public decimal getPurchasePrice { get { return purchasePrice; } }
        public long getSharesOwned { get { return sharesOwned; } }
        public decimal CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }
        public decimal Worth { get { return currentPrice * sharesOwned; } }


    }//end stock class

    public class Portfolio
    {
        Stock[] stocks;

        public Portfolio(int numberofstocks)
        {
            stocks = new Stock[numberofstocks]; //create an array with specific size
        }
        public Stock this[int index] //indexer
        {
            get { return stocks[index]; }
            set { stocks[index] = value; }
        }
        public int NumberOfStocks
        {
            get { return stocks.Length; }
        }
    }//end portfolio class

    class Test
    {
        static void Main(string[] args)
        {
            Portfolio portfolio = new Portfolio(3);
            portfolio[0] = new Stock("MSFT", 20, 1000);
            portfolio[1] = new Stock("GOOG", 300, 100);
            portfolio[2] = new Stock("APPL", 50, 750);

            for( int i = 0; i < portfolio.NumberOfStocks ;i++)
                Console.WriteLine(portfolio[i].getSymbol);
            7
        }
    }
}
