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

            while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Please input your name");
                    name = Console.ReadLine();
                }
           
            Console.WriteLine("Please input your sex (male or female)");
                string sex = Console.ReadLine();
                sex = sex.ToLower();
            bool validSex = false;
                string option1 = "male";
                string option2 = "female";
            while (validSex)
            {
                if (!string.IsNullOrWhiteSpace(sex))
                {
                    if (sex == option1 || sex == option2)
                    {
                        validSex = true;
                    }
                    else if (sex != option1 && sex != option2)
                    {
                        validSex = false;
                        Console.WriteLine("Please input your sex (male or female)");
                        sex = Console.ReadLine();
                    }
                    
                }
                else if (string.IsNullOrWhiteSpace(sex))
                {
                    Console.WriteLine("Please input your name");
                    sex = Console.ReadLine();
                }
            }


            DateTime time = DateTime.Now;
                bool morning = time.Hour <= 11;
                bool evening = time.Hour >= 18;
                bool afternoon = time.Hour < 18;

                DateTime maleResponse = DateTime.Now;
                if ((sex == option1) && (morning))
                {
                    Console.WriteLine($"Good morning Mr. {name} and welcome to your favorite stock requisition advisor!");
                }

                else if ((sex == option1) && (afternoon))
                {
                    Console.WriteLine($"Good afternoon Mr. {name} and welcome to your favorite stock requisition advisor!");
                }

                else if ((sex == option1) && (evening))
                {
                    Console.WriteLine($"Good evening Mr. {name} and welcome to your favorite stock requisition advisor!");
                }


                else if (sex == option2)
                {
                    Console.WriteLine("Are you single or married");
                    string maritalStatus = Console.ReadLine();
                    maritalStatus = maritalStatus.ToLower();
                    string firstOption = "single";
                    string secondOption = "married";

                    if ((maritalStatus == firstOption) && (morning))
                    {
                        Console.WriteLine($"Good morning Miss. {name} and welcome to your favorite stock requisition advisor!");
                    }

                    else if ((maritalStatus == firstOption) && (afternoon))
                    {
                        Console.WriteLine($"Good afternoon Miss. {name} and welcome to your favorite stock requisition advisor!");
                    }

                    else if ((maritalStatus == firstOption) && (evening))
                    {
                        Console.WriteLine($"Good evening Miss. {name} and welcome to your favorite stock requisition advisor!");
                    }

                    else if ((maritalStatus == secondOption) && (morning))
                    {
                        Console.WriteLine($"Good morning Mrs. {name} and welcome to your favorite stock requisition advisor!");

                    }

                    else if ((maritalStatus == secondOption) && (afternoon))
                    {
                        Console.WriteLine($"Good afternoon Mrs. {name} and welcome to your favorite stock requisition advisor!");

                    }

                    else if ((maritalStatus == secondOption) && (evening))
                    {
                        Console.WriteLine($"Good evening Mrs. {name} and welcome to your favorite stock requisition advisor!");

                    }
                }


                DateTime femaleResponse = DateTime.Now;


                string[] newsPaperName = { "PMNews newspaper", "Guardian newspaper", "Punch newspaper", "The Sun newspaper" };

                //Declaration  of weekly sales quantity
                int[] PMNewsWeeklyQuantity = { 23, 20, 18, 14 };
                int[] guardianWeeklyQuantity = { 10, 32, 27, 21 };
                int[] punchWeeklyQuantity = { 12, 20, 35, 19 };
                int[] theSunWeeklyQuantity = { 7, 10, 13, 8 };

                //Here I obtain the average sales per product
                double PMNewsWeeklyQuantityAverage = Queryable.Average(PMNewsWeeklyQuantity.AsQueryable());
                double guardianWeeklyQuantityAverage = Queryable.Average(guardianWeeklyQuantity.AsQueryable());
                double punchWeeklyQuantityAverage = Queryable.Average(punchWeeklyQuantity.AsQueryable());
                double theSunWeeklyQuantityAverage = Queryable.Average(theSunWeeklyQuantity.AsQueryable());


                //Declaration of weekly price quantity
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

                double[] totalAverageRevenuePerUnit = { PMNewsAverageRevenuePerUnit, guardianAverageRevenuePerUnit, punchAverageRevenuePerUnit, theSunAverageRevenuePerUnit };

                //Here I obtain the highest average revenue generated per unit of each product sold in order to be able to predict which product generates more revenue
                double highestAverageRevenuePerUnit = totalAverageRevenuePerUnit.Max();


                if (highestAverageRevenuePerUnit == PMNewsAverageRevenuePerUnit)
                {
                    Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[0]}! \nBecause you generate an average revenue of {string.Format("{0:c}", totalAverageRevenuePerUnit[0])} per product sold,  which is {string.Format("{0:c}", PMNewsAverageRevenuePerUnit - guardianAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[1]} per product sold, {string.Format("{0:c}", PMNewsAverageRevenuePerUnit - punchAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[2]} per product sold, and {string.Format("{0:c}", PMNewsAverageRevenuePerUnit - theSunAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[3]} per product sold");
                }

                else if (highestAverageRevenuePerUnit == guardianAverageRevenuePerUnit)
                {
                    Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[1]}! \nBecause you generate an average revenue of {string.Format("{0:c}", totalAverageRevenuePerUnit[1])} per product sold, which is {string.Format("{0:c}", guardianAverageRevenuePerUnit - PMNewsAverageRevenuePerUnit)} more than the average revenue of{newsPaperName[0]} per product sold, {string.Format("{0:c}", guardianAverageRevenuePerUnit - punchAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[2]} per product sold, and {string.Format("{0:c}", guardianAverageRevenuePerUnit - theSunAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[3]} per product sold");
                }

                else if (highestAverageRevenuePerUnit == punchAverageRevenuePerUnit)
                {
                    Console.WriteLine($"Based on analysis conducted on the data we received from you we advise that you stock up on {newsPaperName[2]}! \nBecause you generate an average revenue of {string.Format("{0:c}", totalAverageRevenuePerUnit[2])} per product sold, which is {string.Format("{0:c}", punchAverageRevenuePerUnit - PMNewsAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[0]} per product sold, {string.Format("{0:c}", punchAverageRevenuePerUnit - guardianAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[1]} per product sold, and {string.Format("{0:c}", punchAverageRevenuePerUnit - theSunAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[3]} per product sold");
                }

                else if (highestAverageRevenuePerUnit == theSunAverageRevenuePerUnit)
                {
                    Console.WriteLine($"Based on analysis conducted on the data we received from you, \nWe advise that you stock up on {newsPaperName[3]}! \nBecause you generate an average revenue of {string.Format("{0:c}", totalAverageRevenuePerUnit[3])} which is {string.Format("{0:c}", theSunAverageRevenuePerUnit - guardianAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[1]} per product sold, {string.Format("{0:c}", theSunAverageRevenuePerUnit - punchAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[2]} per product sold, and {string.Format("{0:c}", theSunAverageRevenuePerUnit - PMNewsAverageRevenuePerUnit)} more than the average revenue of {newsPaperName[0]} per product sold");
                }


                DateTime finalResponse = DateTime.Now;

                if ((sex == option1) && (morning))
                {
                    TimeSpan timeSpent = finalResponse - maleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed \nDo have a lovely morning Mr. {name}");
                }

                else if ((sex == option1) && (afternoon))
                {
                    TimeSpan timeSpent = finalResponse - maleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed \nDo have a lovely afternoon Mr. {name}");
                }

                else if ((sex == option1) && (evening))
                {
                    TimeSpan timeSpent = finalResponse - maleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed \nDo have a lovely evening Mr. {name}");
                }


                else if ((sex == option2) && (morning))
                {
                    TimeSpan timeSpent = finalResponse - femaleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed? \nDo have a lovely morning {name}");
                }

                else if ((sex == option2) && (afternoon))
                {
                    TimeSpan timeSpent = finalResponse - femaleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed? \nDo have a lovely afternoon {name}");
                }

                else if ((sex == option2) && (evening))
                {
                    TimeSpan timeSpent = finalResponse - femaleResponse;
                    double timeSpan = timeSpent.TotalMilliseconds;
                    Console.WriteLine($"It took {timeSpan} milliseconds to complete this analysis! \nWe hope you're impressed? \nDo have a lovely evening {name}");
                }


                Console.ReadLine();
        }
    }
}
