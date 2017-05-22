using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineExpert_V2
{
    public class Wine
    {
        public int ID { get; set; }

        public int Type { get; set; } // White or Red 

        public double FixedAcidity { get; set; }
        public double VolatileAcidity { get; set; }
        public double ResidualSugar { get; set; }
        public double Chlorides { get; set; }
        public double FreeSulfurDioxide { get; set; }
        public double TotalSulfurDioxide { get; set; }
        public double Density { get; set; }
        public double PH { get; set; }
        public double Sulphates { get; set; }
        public double Alcohol { get; set; }
        public double QualityOriginal { get; set; }
        public double Quality1 { get; set; }
        public double Quality2 { get; set; }
        public double Quality3 { get; set; }
        public double Quality4 { get; set; }
        public double Quality5 { get; set; }
        public double Quality6 { get; set; }
        public double Quality7 { get; set; }
        public double Quality8 { get; set; }
        public double Quality9 { get; set; }
        public double Quality10 { get; set; }

        public double temp1 { get; set; }
        public double temp2 { get; set; }
        public double temp3 { get; set; }

        public double GetArray(int i)
        {
            switch (i)
            {
                case 0: return FixedAcidity;
                case 1: return VolatileAcidity;
                case 2: return ResidualSugar;
                case 3: return Chlorides;
                case 4: return FreeSulfurDioxide;
                case 5: return TotalSulfurDioxide;
                case 6: return Density;
                case 7: return PH;
                case 8: return Sulphates;
                case 9: return Alcohol;
                case 10: return QualityOriginal;
                default: return 0;
            } 
        }

    }
}
