using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPredictionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input your name");
            string name = Console.ReadLine();

            Console.WriteLine("Please input your sex (male or female)");
            string sex = Console.ReadLine();
            sex = sex.ToLower();
            string option1 = "male";
            string option2 = "female";
            DateTime maleResponse = DateTime.Now;
            if (sex == option1)
            {
                Console.WriteLine($"Hello! Mr. {name} and welcome to your favorite stock requisition advisor!");
            }


            else if (sex == option2)
            {
                Console.WriteLine("Are you single or married");
                string maritalStatus = Console.ReadLine();
                maritalStatus = maritalStatus.ToLower();
                string firstOption = "single";
                string secondOption = "married";
                
                if (maritalStatus == firstOption)
                {
                    Console.WriteLine($"Hello! Miss. {name} and welcome to your favorite stock requisition advisor!");
                }

                else if (maritalStatus == secondOption)
                {
                    Console.WriteLine($"Hello! Mrs. {name} and welcome to your favorite stock requisition advisor!");
                   
                }
            }
            DateTime femaleResponse = DateTime.Now;


            string[] newsPaperName = { "PMNews", "Guardian", "Punch", "The Sun" };

            int[] PMNewsWeeklyQuantity = { 23, 20, 18, 14 };
            int[] guardianWeeklyQuantity = { 10, 32, 27, 21 };
            int[] punchWeeklyQuantity = { 12, 20, 35, 19 };
            int[] theSunWeeklyQuantity = { 7, 10, 13, 8 };

            //Here I obtain the average sales per product
            double PMNewsWeeklyQuantityAverage = Queryable.Average(PMNewsWeeklyQuantity.AsQueryable());
            double guardianWeeklyQuantityAverage = Queryable.Average(guardianWeeklyQuantity.AsQueryable());
            double punchWeeklyQuantityAverage = Queryable.Average(punchWeeklyQuantity.AsQueryable());
            double theSunWeeklyQuantityAverage = Queryable.Average(theSunWeeklyQuantity.AsQueryable());

            double[] PMNewsWeeklyPrice = { 324.56, 300, 315.28, 340 };
            double[] guardianWeeklyPrice = { 324.56, 300, 315.28, 340 };
            double[] punchWeeklyPrice = { 245.35, 220, 265.5, 290.14 };
            double[] theSunWeeklyPrice = { 420, 400, 450.24, 400 };
            
            //Here I obtain the average price per product
            double PMNewsWeeklyPriceAverage = Queryable.Average(PMNewsWeeklyPrice.AsQueryable());
            double guardianWeeklyPriceAverage = Queryable.Average(guardianWeeklyPrice.AsQueryable());
            double punchWeeklyPriceAverage = Queryable.Average(punchWeeklyPrice.AsQueryable());
            double theSunWeeklyPriceAverage = Queryable.Average(theSunWeeklyPrice.AsQueryable());

            //Here I obtain the average revenue generated per unit of each product sold
            double PMNewsAverageRevenuePerUnit = PMNewsWeeklyPriceAverage / PMNewsWeeklyQuantityAverage;
            double guardianAverageRevenuePerUnit = guardianWeeklyPriceAverage / guardianWeeklyQuantityAverage;
            double punchAverageRevenuePerUnit = punchWeeklyPriceAverage / punchWeeklyQuantityAverage;
            double theSunAverageRevenuePerUnit = theSunWeeklyPriceAverage / theSunWeeklyQuantityAverage;

            double[] totalAverageRevenuePerUnit = { PMNewsAverageRevenuePerUnit , guardianAverageRevenuePerUnit, punchAverageRevenuePerUnit, theSunAverageRevenuePerUnit };

            //Here I obtain the highest average revenue generated per unit of each product sold in order to be able to predict which product generates more revenue
            double highestAverageRevenuePerUnit = totalAverageRevenuePerUnit.Max();

            
            if (highestAverageRevenuePerUnit == PMNewsAverageRevenuePerUnit)
            {
                Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[0]} newspaper!");
            }

            else if (highestAverageRevenuePerUnit == guardianAverageRevenuePerUnit)
            {
                Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[1]} newspaper!");
            }

            else if (highestAverageRevenuePerUnit == punchAverageRevenuePerUnit)
            {
                Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[2]} newspaper!");
            }

            else if (highestAverageRevenuePerUnit == theSunAverageRevenuePerUnit)
            {
                Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[3]} newspaper!");
            }

            DateTime finalResponse = DateTime.Now;

            if (sex == option1)
            {
                TimeSpan timeSpent = finalResponse - maleResponse;
                double timeSpan = timeSpent.TotalMilliseconds;
                Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \n We hope you're impressed");
            }


            else if (sex == option2)
            {
                TimeSpan timeSpent = finalResponse - femaleResponse;
                double timeSpan = timeSpent.TotalMilliseconds;
                Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \n We hope you're impressed");
            }
               

            Console.ReadLine();
        }
    }
}
