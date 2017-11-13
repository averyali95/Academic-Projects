using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class Program
    {
        public class UnitConverter
        {
            int ratio;
            public UnitConverter(int unitRatio) { ratio = unitRatio; }
            public int Convert(int unit){return unit*ratio;}     
        }
   
        static void Main(string[] args)
        {
            int num1,num2,num3;

            UnitConverter feetToInches = new UnitConverter(12);
            UnitConverter milesToFeet = new UnitConverter(5280);

            num1 = feetToInches.Convert(30);
            num2 = milesToFeet.Convert(100);
            num3 = feetToInches.Convert(milesToFeet.Convert(1));
        }
    }
}