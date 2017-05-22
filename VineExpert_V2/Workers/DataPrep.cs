using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineExpert_V2
{
    class DataPrep
    {

        public List<Wine> RedWineTrainSet = new List<Wine>();
        public List<Wine> WhiteWineTrainSet = new List<Wine>();
        public List<Wine> RedWineTestSet = new List<Wine>();
        public List<Wine> WhiteWineTestSet = new List<Wine>();


        private List<Red> RedWineAllSet = new List<Red>();
        private List<White> WhiteWineAllSet = new List<White>();

        private List<Red> RedWineOriginalSet = new List<Red>();
        private List<White> WhiteWineOriginalSet = new List<White>();

        public List<Wine> RedWineOriginalSetTransformed = new List<Wine>();
        public List<Wine> WhiteWineOriginalSetTransformed = new List<Wine>();

        


        public DataPrep()
        {
            

        }

        public void Initialize()
        {
            ExtractData();
            TransformData();
            RedWineOriginalSetTransformed = NormalizeData(RedWineOriginalSetTransformed);
            WhiteWineOriginalSetTransformed = NormalizeData(WhiteWineOriginalSetTransformed);
            SeperateTestData(RedWineOriginalSetTransformed);
            SeperateTestData(WhiteWineOriginalSetTransformed);
        }

        

        private void ExtractData()
        {

            WineEntities AllWines = new WineEntities();

            RedWineOriginalSet.AddRange(AllWines.Red.ToList());
            WhiteWineOriginalSet.AddRange(AllWines.White.ToList());

        }


        private void TransformData()
        {


            foreach (Red wine in RedWineOriginalSet)
            {
                RedWineOriginalSetTransformed.Add(
                        new Wine()
                        {
                            ID = wine.ID,
                            Type = 1, //RED
                            FixedAcidity = wine.FixedAcidity,
                            VolatileAcidity = wine.VolatileAcidity,
                            ResidualSugar = wine.ResidualSugar,
                            Chlorides = wine.Chlorides,
                            FreeSulfurDioxide = wine.FreeSulfurDioxide,
                            TotalSulfurDioxide = wine.TotalSulfurDioxide,
                            Density = wine.Density,
                            PH = wine.PH,
                            Sulphates = wine.Sulphates,
                            Alcohol = wine.Alcohol,
                            QualityOriginal = wine.Quality,
                            Quality1 = wine.Quality  == 1.0 ? 1.0 : 0,
                            Quality2 = wine.Quality  == 2.0 ? 1.0 : 0,
                            Quality3 = wine.Quality  == 3.0 ? 1.0 : 0,
                            Quality4 = wine.Quality  == 4.0 ? 1.0 : 0,
                            Quality5 = wine.Quality  == 5.0 ? 1.0 : 0,
                            Quality6 = wine.Quality  == 6.0 ? 1.0 : 0,
                            Quality7 = wine.Quality  == 7.0 ? 1.0 : 0,
                            Quality8 = wine.Quality  == 8.0 ? 1.0 : 0,
                            Quality9 = wine.Quality  == 9.0 ? 1.0 : 0,
                            Quality10 = wine.Quality == 10.0 ? 1.0 : 0
                        }
                    );

            }

            foreach (White wine in WhiteWineOriginalSet)
            {
                WhiteWineOriginalSetTransformed.Add(
                        new Wine()
                        {
                            ID = wine.ID,
                            Type = 2, //WHITE
                            FixedAcidity = wine.FixedAcidity,
                            VolatileAcidity = wine.VolatileAcidity,
                            ResidualSugar = wine.ResidualSugar,
                            Chlorides = wine.Chlorides,
                            FreeSulfurDioxide = wine.FreeSulfurDioxide,
                            TotalSulfurDioxide = wine.TotalSulfurDioxide,
                            Density = wine.Density,
                            PH = wine.PH,
                            Sulphates = wine.Sulphates,
                            Alcohol = wine.Alcohol,
                            QualityOriginal = wine.Quality,
                            Quality1 = wine.Quality  == 1.0 ? 1.0 : 0,
                            Quality2 = wine.Quality  == 2.0 ? 1.0 : 0,
                            Quality3 = wine.Quality  == 3.0 ? 1.0 : 0,
                            Quality4 = wine.Quality  == 4.0 ? 1.0 : 0,
                            Quality5 = wine.Quality  == 5.0 ? 1.0 : 0,
                            Quality6 = wine.Quality  == 6.0 ? 1.0 : 0,
                            Quality7 = wine.Quality  == 7.0 ? 1.0 : 0,
                            Quality8 = wine.Quality  == 8.0 ? 1.0 : 0,
                            Quality9 = wine.Quality  == 9.0 ? 1.0 : 0,
                            Quality10 = wine.Quality == 10.0 ? 1.0 : 0
                        }
                    );

            }

        }



        private void SeperateTestData(List<Wine> Wines)
        {
            Random rnd = new Random();

            int testCountRed = RedWineOriginalSet.Count() / 5;
            int testCountWhite = WhiteWineOriginalSet.Count() / 5;

            if (Wines.FirstOrDefault().Type == 1)
            {
                RedWineTestSet = Wines.OrderBy(user => rnd.Next()).Take(testCountRed).ToList();
                RedWineTrainSet = Wines.Where(x => !RedWineTestSet.Any(y => y.ID == x.ID)).ToList();
            }
            else
            {
                WhiteWineTestSet = Wines.OrderBy(user => rnd.Next()).Take(testCountWhite).ToList();
                WhiteWineTrainSet = Wines.Where(x => !WhiteWineTestSet.Any(y => y.ID == x.ID)).ToList();
            }
        }


        private List<Wine> NormalizeData(List<Wine> Wines)
        {
            double FixedAcidity_Mean, VolatileAcidity_Mean, ResidualSugar_Mean, Chlorides_Mean, FreeSulfurDioxide_Mean, TotalSulfurDioxide_Mean, Density_Mean,
            PH_Mean, Sulphates_Mean, Alcohol_Mean;

            double FixedAcidity_StdDev, VolatileAcidity_StdDev, ResidualSugar_StdDev, Chlorides_StdDev, FreeSulfurDioxide_StdDev, TotalSulfurDioxide_StdDev, Density_StdDev,
            PH_StdDev, Sulphates_StdDev, Alcohol_StdDev;


            FixedAcidity_Mean = Wines.Select(x => x.FixedAcidity).ToList().Sum() / Wines.Count;
            VolatileAcidity_Mean = Wines.Select(x => x.VolatileAcidity).ToList().Sum() / Wines.Count;
            ResidualSugar_Mean = Wines.Select(x => x.ResidualSugar).ToList().Sum() / Wines.Count;
            Chlorides_Mean = Wines.Select(x => x.Chlorides).ToList().Sum() / Wines.Count;
            FreeSulfurDioxide_Mean = Wines.Select(x => x.FreeSulfurDioxide).ToList().Sum() / Wines.Count;
            TotalSulfurDioxide_Mean = Wines.Select(x => x.TotalSulfurDioxide).ToList().Sum() / Wines.Count;
            Density_Mean = Wines.Select(x => x.Density).ToList().Sum() / Wines.Count;
            PH_Mean = Wines.Select(x => x.PH).ToList().Sum() / Wines.Count;
            Sulphates_Mean = Wines.Select(x => x.Sulphates).ToList().Sum() / Wines.Count;
            Alcohol_Mean = Wines.Select(x => x.FixedAcidity).ToList().Sum() / Wines.Count;

            FixedAcidity_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.FixedAcidity - FixedAcidity_Mean, 2)) / Wines.Count);
            VolatileAcidity_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.VolatileAcidity - VolatileAcidity_Mean, 2)) / Wines.Count);
            ResidualSugar_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.ResidualSugar - ResidualSugar_Mean, 2)) / Wines.Count);
            Chlorides_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.Chlorides - Chlorides_Mean, 2)) / Wines.Count);
            FreeSulfurDioxide_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.FreeSulfurDioxide - FreeSulfurDioxide_Mean, 2)) / Wines.Count);
            TotalSulfurDioxide_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.TotalSulfurDioxide - TotalSulfurDioxide_Mean, 2)) / Wines.Count);
            Density_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.Density - Density_Mean, 2)) / Wines.Count);
            PH_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.PH - PH_Mean, 2)) / Wines.Count);
            Sulphates_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.Sulphates - Sulphates_Mean, 2)) / Wines.Count);
            Alcohol_StdDev = Math.Sqrt(Wines.Sum(x => Math.Pow(x.Alcohol - Alcohol_Mean, 2)) / Wines.Count);

            Wines.ToList().ForEach(x => x.FixedAcidity = Convert.ToSingle(((x.FixedAcidity) - FixedAcidity_Mean) / FixedAcidity_StdDev));
            Wines.ToList().ForEach(x => x.VolatileAcidity = Convert.ToSingle(((x.VolatileAcidity) - VolatileAcidity_Mean) / VolatileAcidity_StdDev));
            Wines.ToList().ForEach(x => x.ResidualSugar = Convert.ToSingle(((x.ResidualSugar) - ResidualSugar_Mean) / ResidualSugar_StdDev));
            Wines.ToList().ForEach(x => x.Chlorides = Convert.ToSingle(((x.Chlorides) - Chlorides_Mean) / Chlorides_StdDev));
            Wines.ToList().ForEach(x => x.FreeSulfurDioxide = Convert.ToSingle(((x.FreeSulfurDioxide) - FreeSulfurDioxide_Mean) / FreeSulfurDioxide_StdDev));
            Wines.ToList().ForEach(x => x.TotalSulfurDioxide = Convert.ToSingle(((x.TotalSulfurDioxide) - TotalSulfurDioxide_Mean) / TotalSulfurDioxide_StdDev));
            Wines.ToList().ForEach(x => x.Density = Convert.ToSingle(((x.Density) - Density_Mean) / Density_StdDev));
            Wines.ToList().ForEach(x => x.PH = Convert.ToSingle(((x.PH) - PH_Mean) / PH_StdDev));
            Wines.ToList().ForEach(x => x.Sulphates = Convert.ToSingle(((x.Sulphates) - Sulphates_Mean) / Sulphates_StdDev));
            Wines.ToList().ForEach(x => x.Alcohol = Convert.ToSingle(((x.Alcohol) - Alcohol_Mean) / Alcohol_StdDev));




           
            return Wines;
        }

    }
}
