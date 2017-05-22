using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineExpert_V2
{
    class Perceptron
    {

        public Perceptron()
        {

        }

        public string WineTrain(List<Wine> TrainSet,List<Wine> TestSet)
        {
            //Variables
            Random rnd = new Random();
            double[] weights = { rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(),
                                 rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble() };

            //double[] weights = { 0.014, -1.003, 0.015, -2.011, 0.005,-0.004, -18.112, -0.406, 0.913, 0.271 };


            //PARAMETERS
            double learningRate = 0.01;
            int iterationLimit = 10000;
            int localErrorLimit = 3;


            int iteration = 0;
            double globalError;
            int patternCount = TrainSet.Count;
            //Variables
            StringBuilder str = new StringBuilder();
            str.AppendLine("Initial Weights : ");
            str.AppendLine("FixedAcidity: " + weights[0].ToString());
            str.AppendLine("VolatileAcidity : " + weights[1].ToString());
            str.AppendLine("\nResidualSugar : " + weights[2].ToString());
            str.AppendLine("\nChlorides : " + weights[3].ToString());
            str.AppendLine("\nFreeSulfurDioxide : " + weights[4].ToString());
            str.AppendLine("\nTotalSulfurDioxide : " + weights[5].ToString());
            str.AppendLine("\nDensity : " + weights[6].ToString());
            str.AppendLine("\nPH : " + weights[7].ToString());
            str.AppendLine("\nSulphates : " + weights[8].ToString());
            str.AppendLine("\nAlcohol : " + weights[9].ToString());
            str.AppendLine();
            str.AppendLine();

            do
            {
                globalError = 0;
                for (int p = 0; p < patternCount; p++)
                {

                    //FixedAcidity real   
                    //VolatileAcidity real 
                    //ResidualSugar   real 
                    //Chlorides real    
                    //FreeSulfurDioxide   real 
                    //TotalSulfurDioxide smallint    
                    //Density real 
                    //PH real    
                    //Sulphates   real 
                    //Alcohol real    
                    //Quality smallint 
                    // Calculate output.
                    double output = Output(weights, 
                                        TrainSet.ElementAt(p).FixedAcidity,
                                        TrainSet.ElementAt(p).VolatileAcidity,
                                        TrainSet.ElementAt(p).ResidualSugar,
                                        TrainSet.ElementAt(p).Chlorides,
                                        TrainSet.ElementAt(p).FreeSulfurDioxide,
                                        TrainSet.ElementAt(p).TotalSulfurDioxide,
                                        TrainSet.ElementAt(p).Density,
                                        TrainSet.ElementAt(p).PH,
                                        TrainSet.ElementAt(p).Sulphates,
                                        TrainSet.ElementAt(p).Alcohol,
                                        TrainSet.ElementAt(p).QualityOriginal);

                    // Calculate error.
                    double localError = TrainSet.ElementAt(p).QualityOriginal - output;
                    

                    if (Math.Abs(localError) > localErrorLimit)
                    {
                        // Update weights.
                        for (int i = 0; i < 10; i++)
                        {
                            weights[i] += learningRate * localError * TrainSet.ElementAt(p).GetArray(i);
                        }
                    }
                    
                    globalError += Math.Abs(localError);
                }

                
                iteration++;

            } while ( iteration!= iterationLimit); //globalError != 0 ||

            //Console.WriteLine();
            //Console.WriteLine("X, Y, Output");
            
            List<string> results = new List<string>();

            double Error = 0;
            int CorrectCount = 0;
            int FalseCount = 0;

            foreach(Wine Wine in TestSet)
            { 
                // Calculate output.
                double output = Output(weights,
                                    Wine.FixedAcidity,
                                    Wine.VolatileAcidity,
                                    Wine.ResidualSugar,
                                    Wine.Chlorides,
                                    Wine.FreeSulfurDioxide,
                                    Wine.TotalSulfurDioxide,
                                    Wine.Density,
                                    Wine.PH,
                                    Wine.Sulphates,
                                    Wine.Alcohol,
                                    Wine.QualityOriginal);
                Error += Math.Abs(Wine.QualityOriginal - output);
                if (Math.Abs(Wine.QualityOriginal - output) < 1)
                    CorrectCount++;
                else
                    FalseCount++; 
                str.AppendLine(String.Format("Expected Quality ;{0};Result Quality ;{1};Difference ;{2}; Category ;{3}", Wine.QualityOriginal, output, Wine.QualityOriginal-output,(Math.Abs(Wine.QualityOriginal - output) < 1) ? "True" : "False"));
            }
            str.AppendLine("Final Weights : ");
            str.AppendLine("FixedAcidity: " + weights[0].ToString());
            str.AppendLine("VolatileAcidity : " + weights[1].ToString());
            str.AppendLine("\nResidualSugar : " + weights[2].ToString());
            str.AppendLine("\nChlorides : " + weights[3].ToString());
            str.AppendLine("\nFreeSulfurDioxide : " + weights[4].ToString());
            str.AppendLine("\nTotalSulfurDioxide : " + weights[5].ToString());
            str.AppendLine("\nDensity : " + weights[6].ToString());
            str.AppendLine("\nPH : " + weights[7].ToString());
            str.AppendLine("\nSulphates : " + weights[8].ToString());
            str.AppendLine("\nAlcohol : " + weights[9].ToString());
            str.AppendLine();
            str.AppendLine();


            str.AppendLine("Average Error Per Item : " + Error / TestSet.Count + ", Correct Count : " + CorrectCount+ "("+ CorrectCount*100/TestSet.Count + "%)" + ", False Count : " + FalseCount + "(" + FalseCount*100 / TestSet.Count + "%)");
            return str.ToString();
        }



        private double Output(double[] weights, 
                                        double FixedAcidity,
                                        double VolatileAcidity,
                                        double ResidualSugar,
                                        double Chlorides,
                                        double FreeSulfurDioxide,
                                        double TotalSulfurDioxide,
                                        double Density,
                                        double PH,
                                        double Sulphates,
                                        double Alcohol,
                                        double Quality)
        {

            double sum = FixedAcidity * weights[0] +
                         VolatileAcidity * weights[1] +
                         ResidualSugar * weights[2] +
                         Chlorides * weights[3] +
                         FreeSulfurDioxide * weights[4] +
                         TotalSulfurDioxide * weights[5] +
                         Density * weights[6] +
                         PH * weights[7] +
                         Sulphates * weights[8] +
                         Alcohol * weights[9];

            return LogSigmoid(sum);
        }

        public double LogSigmoid(double x)
        {
            if (x < -45.0) return 0.0;
            else if (x > 45.0) return 1.0;
            else return (1.0 / (1.0 + Math.Exp(-x))) * 10.0;//Scale result between 0 and 10;
        }

        
    }
}
