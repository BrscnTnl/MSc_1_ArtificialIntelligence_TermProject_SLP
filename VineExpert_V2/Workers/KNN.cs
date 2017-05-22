using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineExpert_V2
{
    public class KNN
    {

        double[,] scores = new double[10, 10];
        private List<Wine> _wines = new List<Wine>();
        public KNN(List<Wine> wines)
        {
            _wines = wines;

            for (int i = 0; i < 10; i++)
            {
                scores[i, 0] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.FixedAcidity).ToList().Sum() / _wines.Count;
                scores[i, 1] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.VolatileAcidity).ToList().Sum() / _wines.Count;
                scores[i, 2] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.ResidualSugar).ToList().Sum() / _wines.Count;
                scores[i, 3] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.Chlorides).ToList().Sum() / _wines.Count;
                scores[i, 4] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.FreeSulfurDioxide).ToList().Sum() / _wines.Count;
                scores[i, 5] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.TotalSulfurDioxide).ToList().Sum() / _wines.Count;
                scores[i, 6] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.Density).ToList().Sum() / _wines.Count;
                scores[i, 7] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.PH).ToList().Sum() / _wines.Count;
                scores[i, 8] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.Sulphates).ToList().Sum() / _wines.Count;
                scores[i, 9] = _wines.Where(y => y.QualityOriginal == i).Select(x => x.Alcohol).ToList().Sum() / _wines.Count;
            }
        }


        public int[] GetIndividualScore(Wine _wine)
        {

            
            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;

            foreach (Wine x in _wines)
            {

                CumulativeEuclideanDistance = Math.Sqrt(Euclidean(x.FixedAcidity, _wine.FixedAcidity) +
                                             Euclidean(x.VolatileAcidity, _wine.VolatileAcidity) +
                                             Euclidean(x.ResidualSugar, _wine.ResidualSugar) +
                                             Euclidean(x.Chlorides, _wine.Chlorides) +
                                             Euclidean(x.FreeSulfurDioxide, _wine.FreeSulfurDioxide) +
                                             Euclidean(x.TotalSulfurDioxide, _wine.TotalSulfurDioxide) +
                                             Euclidean(x.Density, _wine.Density) +
                                             Euclidean(x.PH, _wine.PH) +
                                             Euclidean(x.Sulphates, _wine.Sulphates) +
                                             Euclidean(x.Alcohol, _wine.Alcohol));

                x.temp1 = CumulativeEuclideanDistance;


                CumulativeManhattanDistance = Manhattan(x.FixedAcidity, _wine.FixedAcidity) +
                                             Manhattan(x.VolatileAcidity, _wine.VolatileAcidity) +
                                             Manhattan(x.ResidualSugar, _wine.ResidualSugar) +
                                             Manhattan(x.Chlorides, _wine.Chlorides) +
                                             Manhattan(x.FreeSulfurDioxide, _wine.FreeSulfurDioxide) +
                                             Manhattan(x.TotalSulfurDioxide, _wine.TotalSulfurDioxide) +
                                             Manhattan(x.Density, _wine.Density) +
                                             Manhattan(x.PH, _wine.PH) +
                                             Manhattan(x.Sulphates, _wine.Sulphates) +
                                             Manhattan(x.Alcohol, _wine.Alcohol);

                x.temp2 = CumulativeManhattanDistance;

                int orderForMinkowski = 2;

                CumulativeMinkowskiDistance = Math.Pow(Minkowski(x.FixedAcidity, _wine.FixedAcidity, orderForMinkowski) +
                                             Minkowski(x.VolatileAcidity, _wine.VolatileAcidity, orderForMinkowski) +
                                             Minkowski(x.ResidualSugar, _wine.ResidualSugar, orderForMinkowski) +
                                             Minkowski(x.Chlorides, _wine.Chlorides, orderForMinkowski) +
                                             Minkowski(x.FreeSulfurDioxide, _wine.FreeSulfurDioxide, orderForMinkowski) +
                                             Minkowski(x.TotalSulfurDioxide, _wine.TotalSulfurDioxide, orderForMinkowski) +
                                             Minkowski(x.Density, _wine.Density, orderForMinkowski) +
                                             Minkowski(x.PH, _wine.PH, orderForMinkowski) +
                                             Minkowski(x.Sulphates, _wine.Sulphates, orderForMinkowski) +
                                             Minkowski(x.Alcohol, _wine.Alcohol, orderForMinkowski), (1 / orderForMinkowski));


                x.temp3 = CumulativeMinkowskiDistance;



            }


            int[] finalScores = new int[4];
            finalScores[0] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp1).Take(10).ToList().Average(y => y.QualityOriginal), 0));
            finalScores[1] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp2).Take(10).ToList().Average(y => y.QualityOriginal), 0));
            finalScores[2] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp3).Take(10).ToList().Average(y => y.QualityOriginal), 0));
            finalScores[3] = (int)_wine.QualityOriginal;


            return finalScores;
        }

        public List<int[]> GetIndividualScore(List<Wine> _wine)
        {

            List<int[]> testResults = new List<int[]>();

            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;

            foreach (Wine y in _wine)
            {
                foreach (Wine x in _wines)
                {

                    CumulativeEuclideanDistance = Math.Sqrt(Euclidean(x.FixedAcidity, y.FixedAcidity) +
                                                 Euclidean(x.VolatileAcidity, y.VolatileAcidity) +
                                                 Euclidean(x.ResidualSugar, y.ResidualSugar) +
                                                 Euclidean(x.Chlorides, y.Chlorides) +
                                                 Euclidean(x.FreeSulfurDioxide, y.FreeSulfurDioxide) +
                                                 Euclidean(x.TotalSulfurDioxide, y.TotalSulfurDioxide) +
                                                 Euclidean(x.Density, y.Density) +
                                                 Euclidean(x.PH, y.PH) +
                                                 Euclidean(x.Sulphates, y.Sulphates) +
                                                 Euclidean(x.Alcohol, y.Alcohol));

                    x.temp1 = CumulativeEuclideanDistance;


                    CumulativeManhattanDistance = Manhattan(x.FixedAcidity, y.FixedAcidity) +
                                                 Manhattan(x.VolatileAcidity, y.VolatileAcidity) +
                                                 Manhattan(x.ResidualSugar, y.ResidualSugar) +
                                                 Manhattan(x.Chlorides, y.Chlorides) +
                                                 Manhattan(x.FreeSulfurDioxide, y.FreeSulfurDioxide) +
                                                 Manhattan(x.TotalSulfurDioxide, y.TotalSulfurDioxide) +
                                                 Manhattan(x.Density, y.Density) +
                                                 Manhattan(x.PH, y.PH) +
                                                 Manhattan(x.Sulphates, y.Sulphates) +
                                                 Manhattan(x.Alcohol, y.Alcohol);

                    x.temp2 = CumulativeManhattanDistance;

                    int orderForMinkowski = 2;

                    CumulativeMinkowskiDistance = Math.Pow(Minkowski(x.FixedAcidity, y.FixedAcidity, orderForMinkowski) +
                                                 Minkowski(x.VolatileAcidity, y.VolatileAcidity, orderForMinkowski) +
                                                 Minkowski(x.ResidualSugar, y.ResidualSugar, orderForMinkowski) +
                                                 Minkowski(x.Chlorides, y.Chlorides, orderForMinkowski) +
                                                 Minkowski(x.FreeSulfurDioxide, y.FreeSulfurDioxide, orderForMinkowski) +
                                                 Minkowski(x.TotalSulfurDioxide, y.TotalSulfurDioxide, orderForMinkowski) +
                                                 Minkowski(x.Density, y.Density, orderForMinkowski) +
                                                 Minkowski(x.PH, y.PH, orderForMinkowski) +
                                                 Minkowski(x.Sulphates, y.Sulphates, orderForMinkowski) +
                                                 Minkowski(x.Alcohol, y.Alcohol, orderForMinkowski), (1 / orderForMinkowski));


                    x.temp3 = CumulativeMinkowskiDistance;



                }


                int[] finalScores = new int[4];
                finalScores[0] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp1).Take(10).ToList().Average(zy => zy.QualityOriginal), 0));
                finalScores[1] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp2).Take(10).ToList().Average(zy => zy.QualityOriginal), 0));
                finalScores[2] = Convert.ToInt32(Math.Round(_wines.OrderBy(x => x.temp3).Take(10).ToList().Average(zy => zy.QualityOriginal), 0));
                finalScores[3] = (int)y.QualityOriginal;
                testResults.Add(finalScores);
            }
            return testResults;
        }

        public int[] GetNearestClusterScore(Wine _wine)
        {


            double CurrentDistanceForEuclidean = 999999, CurrentDistanceForManhattan = 999999, CurrentDistanceForMinkowski = 999999;
            int CurrentScoreForEuclidean = 999999, CurrentScoreForManhattan = 999999, CurrentScoreForMinkowski = 999999;
            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;




            for (int i = 0; i < 10; i++)
            {


                CumulativeEuclideanDistance = Math.Sqrt(Euclidean(scores[i, 0], _wine.FixedAcidity) +
                                             Euclidean(scores[i, 1], _wine.VolatileAcidity) +
                                             Euclidean(scores[i, 2], _wine.ResidualSugar) +
                                             Euclidean(scores[i, 3], _wine.Chlorides) +
                                             Euclidean(scores[i, 4], _wine.FreeSulfurDioxide) +
                                             Euclidean(scores[i, 5], _wine.TotalSulfurDioxide) +
                                             Euclidean(scores[i, 6], _wine.Density) +
                                             Euclidean(scores[i, 7], _wine.PH) +
                                             Euclidean(scores[i, 8], _wine.Sulphates) +
                                             Euclidean(scores[i, 9], _wine.Alcohol));

                if (CumulativeEuclideanDistance < CurrentDistanceForEuclidean)
                {
                    CurrentScoreForEuclidean = i;
                    CurrentDistanceForEuclidean = CumulativeEuclideanDistance;
                }


                CumulativeManhattanDistance =   Manhattan(scores[i, 0], _wine.FixedAcidity) +
                                             Manhattan(scores[i, 1], _wine.VolatileAcidity) +
                                             Manhattan(scores[i, 2], _wine.ResidualSugar) +
                                             Manhattan(scores[i, 3], _wine.Chlorides) +
                                             Manhattan(scores[i, 4], _wine.FreeSulfurDioxide) +
                                             Manhattan(scores[i, 5], _wine.TotalSulfurDioxide) +
                                             Manhattan(scores[i, 6], _wine.Density) +
                                             Manhattan(scores[i, 7], _wine.PH) +
                                             Manhattan(scores[i, 8], _wine.Sulphates) +
                                             Manhattan(scores[i, 9], _wine.Alcohol);

                if (CumulativeManhattanDistance < CurrentDistanceForManhattan)
                {
                    CurrentScoreForManhattan = i;
                    CurrentDistanceForManhattan = CumulativeManhattanDistance;
                }

                int orderForMinkowski = 2;

                CumulativeMinkowskiDistance = Math.Pow(  Minkowski(scores[i, 0], _wine.FixedAcidity, orderForMinkowski) +
                                             Minkowski(scores[i, 1], _wine.VolatileAcidity, orderForMinkowski) +
                                             Minkowski(scores[i, 2], _wine.ResidualSugar, orderForMinkowski) +
                                             Minkowski(scores[i, 3], _wine.Chlorides, orderForMinkowski) +
                                             Minkowski(scores[i, 4], _wine.FreeSulfurDioxide, orderForMinkowski) +
                                             Minkowski(scores[i, 5], _wine.TotalSulfurDioxide, orderForMinkowski) +
                                             Minkowski(scores[i, 6], _wine.Density, orderForMinkowski) +
                                             Minkowski(scores[i, 7], _wine.PH, orderForMinkowski) +
                                             Minkowski(scores[i, 8], _wine.Sulphates, orderForMinkowski) +
                                             Minkowski(scores[i, 9], _wine.Alcohol, orderForMinkowski),(1/ orderForMinkowski));

                if (CumulativeMinkowskiDistance < CurrentDistanceForMinkowski)
                {
                    CurrentScoreForMinkowski = i;
                    CurrentDistanceForMinkowski = CumulativeMinkowskiDistance;
                }


            }

            int[] finalScores = new int[4];
            finalScores[0] = CurrentScoreForEuclidean;
            finalScores[1] = CurrentScoreForManhattan;
            finalScores[2] = CurrentScoreForMinkowski;
            finalScores[3] = (int)_wine.QualityOriginal;

            return finalScores;
        }

        public List<int[]> GetNearestClusterScore(List<Wine> _wine)
        {

            List<int[]> testResults = new List<int[]>();
            double CurrentDistanceForEuclidean = 999999, CurrentDistanceForManhattan = 999999, CurrentDistanceForMinkowski = 999999;
            int CurrentScoreForEuclidean = 999999, CurrentScoreForManhattan = 999999, CurrentScoreForMinkowski = 999999;
            double CumulativeEuclideanDistance, CumulativeManhattanDistance, CumulativeMinkowskiDistance;


            foreach (Wine y in _wine)
            {

                for (int i = 0; i < 10; i++)
                {


                    CumulativeEuclideanDistance = Math.Sqrt( Euclidean(scores[i, 0], y.FixedAcidity) +
                                                             Euclidean(scores[i, 1], y.VolatileAcidity) +
                                                             Euclidean(scores[i, 2], y.ResidualSugar) +
                                                             Euclidean(scores[i, 3], y.Chlorides) +
                                                             Euclidean(scores[i, 4], y.FreeSulfurDioxide) +
                                                             Euclidean(scores[i, 5], y.TotalSulfurDioxide) +
                                                             Euclidean(scores[i, 6], y.Density) +
                                                             Euclidean(scores[i, 7], y.PH) +
                                                             Euclidean(scores[i, 8], y.Sulphates) +
                                                             Euclidean(scores[i, 9], y.Alcohol));

                    if (CumulativeEuclideanDistance < CurrentDistanceForEuclidean)
                    {
                        CurrentScoreForEuclidean = i;
                        CurrentDistanceForEuclidean = CumulativeEuclideanDistance;
                    }


                    CumulativeManhattanDistance = Manhattan(scores[i, 0], y.FixedAcidity) +
                                                  Manhattan(scores[i, 1], y.VolatileAcidity) +
                                                  Manhattan(scores[i, 2], y.ResidualSugar) +
                                                  Manhattan(scores[i, 3], y.Chlorides) +
                                                  Manhattan(scores[i, 4], y.FreeSulfurDioxide) +
                                                  Manhattan(scores[i, 5], y.TotalSulfurDioxide) +
                                                  Manhattan(scores[i, 6], y.Density) +
                                                  Manhattan(scores[i, 7], y.PH) +
                                                  Manhattan(scores[i, 8], y.Sulphates) +
                                                  Manhattan(scores[i, 9], y.Alcohol);

                    if (CumulativeManhattanDistance < CurrentDistanceForManhattan)
                    {
                        CurrentScoreForManhattan = i;
                        CurrentDistanceForManhattan = CumulativeManhattanDistance;
                    }

                    double orderForMinkowski = 2;

                    CumulativeMinkowskiDistance = Math.Pow(  Minkowski(scores[i, 0], y.FixedAcidity, orderForMinkowski) +
                                                             Minkowski(scores[i, 1], y.VolatileAcidity, orderForMinkowski) +
                                                             Minkowski(scores[i, 2], y.ResidualSugar, orderForMinkowski) +
                                                             Minkowski(scores[i, 3], y.Chlorides, orderForMinkowski) +
                                                             Minkowski(scores[i, 4], y.FreeSulfurDioxide, orderForMinkowski) +
                                                             Minkowski(scores[i, 5], y.TotalSulfurDioxide, orderForMinkowski) +
                                                             Minkowski(scores[i, 6], y.Density, orderForMinkowski) +
                                                             Minkowski(scores[i, 7], y.PH, orderForMinkowski) +
                                                             Minkowski(scores[i, 8], y.Sulphates, orderForMinkowski) +
                                                             Minkowski(scores[i, 9], y.Alcohol, orderForMinkowski), (1 / orderForMinkowski));

                    if (CumulativeMinkowskiDistance < CurrentDistanceForMinkowski)
                    {
                        CurrentScoreForMinkowski = i;
                        CurrentDistanceForMinkowski = CumulativeMinkowskiDistance;
                    }


                }

                int[] finalScores = new int[4];
                finalScores[0] = CurrentScoreForEuclidean;
                finalScores[1] = CurrentScoreForManhattan;
                finalScores[2] = CurrentScoreForMinkowski;
                finalScores[3] = (int)y.QualityOriginal;
                testResults.Add(finalScores);
                
            }
            return testResults;
        }

        private double Euclidean(double x,double y)
        {
            return Math.Pow(x - y,2);
        }

        private double Manhattan(double x, double y)
        {
            return Math.Abs(x-y);
        }

        private double Minkowski(double x, double y,double order)
        {
            return Math.Pow(Math.Abs(x - y), order);
        }



    }
}
