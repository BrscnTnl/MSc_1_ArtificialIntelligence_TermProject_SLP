using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VineExpert_V2
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            Random rnd = new Random();
            DataPrep dprp = new DataPrep();
            List<int[]> RandomSample = new List<int[]>();

            List<Wine> RedWineTrainSet = new List<Wine>();
            List<Wine> WhiteWineTrainSet = new List<Wine>();
            List<Wine> RedWineTestSet = new List<Wine>();
            List<Wine> WhiteWineTestSet = new List<Wine>();


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////// ANN ////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////


            
            for (int i = 0; i < 10; i++)
            {
                dprp.Initialize();
                RedWineTrainSet = dprp.RedWineTrainSet;
                WhiteWineTrainSet = dprp.WhiteWineTrainSet;
                RedWineTestSet = dprp.RedWineTestSet;
                WhiteWineTestSet = dprp.WhiteWineTestSet;
                Perceptron pct = new Perceptron();
                result.AppendLine((i + 1) + ".th Run");
                result.AppendLine("");
                result.AppendLine("");
                result.AppendLine("Red");
                result.AppendLine("");
                result.AppendLine(pct.WineTrain(RedWineTrainSet, RedWineTestSet));
                result.AppendLine("");
                result.AppendLine("");
                result.AppendLine("White");
                result.AppendLine("");
                result.AppendLine(pct.WineTrain(WhiteWineTrainSet, WhiteWineTestSet));
                result.AppendLine("");
                result.AppendLine("");
                result.AppendLine("");
                result.AppendLine("End of " + (i + 1) + ".th Run");
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////// ANN ////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////// K-NN & K-Means ///////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////





            //double ErrorEuclidean = 0, ErrorManhattan = 0, ErrorMinkowski = 0;
            //int CorrectEuclidean = 0, CorrectManhattan = 0, CorrectMinkowski = 0;
            //int FalseEuclidean = 0, FalseManhattan = 0, FalseMinkowski = 0;



            //dprp.Initialize();
            //RedWineTrainSet = dprp.RedWineTrainSet;
            //WhiteWineTrainSet = dprp.WhiteWineTrainSet;
            //RedWineTestSet = dprp.RedWineTestSet;
            //WhiteWineTestSet = dprp.WhiteWineTestSet;
            //KNN KNNRedWine = new KNN(RedWineTrainSet);
            //List<int[]> results = KNNRedWine.GetIndividualScore(RedWineTestSet);
            //result.AppendLine("Run " + "1" + " : ");
            //result.AppendLine("");


            //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
            //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
            //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

            //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
            //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
            //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

            //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
            //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
            //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
            //result.AppendLine("Red Wine Individual Average Error");
            //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
            //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
            //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
            //result.AppendLine(
            //    "Red Wine Individual Average Euclidean Error : " + ErrorEuclidean +
            //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / RedWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "Red Wine Individual Average Manhattan Error : " + ErrorManhattan +
            //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / RedWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "Red Wine Individual Average Minkowski Error : " + ErrorMinkowski  +
            //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / RedWineTestSet.Count + "%)");

            //result.AppendLine("Red Wine Individual scores");
            ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
            //foreach (int[] item in results)
            //{
            //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
            //}
            //result.AppendLine();
            //results = KNNRedWine.GetNearestClusterScore(RedWineTestSet);

            //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
            //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
            //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

            //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
            //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
            //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

            //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
            //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
            //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
            //result.AppendLine("Red Wine Cluster Average Error");
            //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
            //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
            //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
            //result.AppendLine(
            //    "Red Wine Nearest Cluster Average Euclidean Error : " + ErrorEuclidean +
            //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / RedWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "Red Wine Nearest Cluster Average Manhattan Error : " + ErrorManhattan +
            //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / RedWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "Red Wine Nearest Cluster Average Minkowski Error : " + ErrorMinkowski  +
            //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / RedWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / RedWineTestSet.Count + "%)");

            ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
            //foreach (int[] item in results)
            //{
            //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
            //}
            //result.AppendLine();


            //KNN KNNWhiteWine = new KNN(WhiteWineTrainSet);
            //results = KNNWhiteWine.GetIndividualScore(WhiteWineTestSet);

            //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
            //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
            //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

            //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
            //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
            //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

            //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
            //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
            //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
            //result.AppendLine("White Wine Individual Average Error");
            //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
            //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
            //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
            //result.AppendLine(
            //    "White Wine Individual Average Euclidean Error : " + ErrorEuclidean +
            //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / WhiteWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "White Wine Individual Average Manhattan Error : " + ErrorManhattan +
            //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / WhiteWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "White Wine Individual Average Minkowski Error : " + ErrorMinkowski +
            //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / WhiteWineTestSet.Count + "%)");
            //result.AppendLine("White Wine Individual scores");
            ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
            //foreach (int[] item in results)
            //{
            //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
            //}
            //result.AppendLine();
            //results = KNNWhiteWine.GetNearestClusterScore(WhiteWineTestSet);

            //ErrorEuclidean = results.Sum(x => (double)Math.Abs(x[0] - x[3])) / (double)results.Count;
            //ErrorManhattan = results.Sum(x => (double)Math.Abs(x[1] - x[3])) / (double)results.Count;
            //ErrorMinkowski = results.Sum(x => (double)Math.Abs(x[2] - x[3])) / (double)results.Count;

            //CorrectEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) <= 1).Count();
            //CorrectManhattan = results.Where(x => Math.Abs(x[1] - x[3]) <= 1).Count();
            //CorrectMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) <= 1).Count();

            //FalseEuclidean = results.Where(x => Math.Abs(x[0] - x[3]) > 1).Count();
            //FalseManhattan = results.Where(x => Math.Abs(x[1] - x[3]) > 1).Count();
            //FalseMinkowski = results.Where(x => Math.Abs(x[2] - x[3]) > 1).Count();
            //result.AppendLine("White Wine Cluster Average Error");
            //result.AppendLine("for Euclidean : " + ErrorEuclidean.ToString());
            //result.AppendLine("for Manhattan : " + ErrorManhattan.ToString());
            //result.AppendLine("for Minkowski : " + ErrorMinkowski.ToString());
            //result.AppendLine(
            //    "White Wine Nearest Cluster Average Euclidean Error : " + ErrorEuclidean +
            //    ", Correct Count : " + CorrectEuclidean + "(" + CorrectEuclidean * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseEuclidean + "(" + FalseEuclidean * 100 / WhiteWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "White Wine Nearest Cluster Average Manhattan Error : " + ErrorManhattan +
            //    ", Correct Count : " + CorrectManhattan + "(" + CorrectManhattan * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseManhattan + "(" + FalseManhattan * 100 / WhiteWineTestSet.Count + "%)");
            //result.AppendLine(
            //    "White Wine Nearest Cluster Average Minkowski Error : " + ErrorMinkowski +
            //    ", Correct Count : " + CorrectMinkowski + "(" + CorrectMinkowski * 100 / WhiteWineTestSet.Count + "%)" +
            //    ", False Count : " + FalseMinkowski + "(" + FalseMinkowski * 100 / WhiteWineTestSet.Count + "%)");

            //result.AppendLine("White Wine Cluster scores");
            ////RandomSample = results.OrderBy(user => rnd.Next()).Take(5).ToList();
            //foreach (int[] item in results)
            //{
            //    result.AppendLine(String.Format("Euclidean : {0}, Manhattan : {1}, Minkowski : {2}, Original : {3}", item[0], item[1], item[2], item[3]));
            //}

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Output.txt", true))
            //{
            //    file.WriteLine(result.ToString());
            //}
            //result.Clear();


            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////// K-NN & K-Means ///////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////

            //textBox1.Text = result.ToString();
        }


    }
}
