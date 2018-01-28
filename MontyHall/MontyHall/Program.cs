
using System;
using System.Collections.Generic;
using System.Linq;


namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please provide the count of the experiments:");

                if (Int32.TryParse(Console.ReadLine(), out int experimentsCount))
                {
                    var resultsS = ExperimentHelper.GetResultsFromSameSamples(experimentsCount);
                    var resultsD = ExperimentHelper.GetResultsFromDifferentSamples(experimentsCount);

                    Console.WriteLine("Result of the \"Change the choice\" strategy on same samples is: {0} wins for {1} attempts({2}%)"
                                                    , resultsS.ChangeTheChoiceWins, experimentsCount,resultsS.GetChangeTheChoiceWinsInPersents);
                    Console.WriteLine("Result of the \"Do not change the choice\" strategy on same samples is: {0} wins for {1} attempts({2}%)"
                                                    , resultsS.DoNotChangeTheChoiceWins, experimentsCount, resultsS.GetDoNotChangeTheChoiceWinsInPersents);
                    Console.WriteLine();

                    Console.WriteLine("Result of the \"Change the choice\" strategy on different samples is: {0} wins for {1} attempts({2}%)"
                                                    , resultsD.ChangeTheChoiceWins, experimentsCount, resultsD.GetChangeTheChoiceWinsInPersents);
                    Console.WriteLine("Result of the \"Do not change the choice\" strategy on different samples is: {0} wins for {1} attempts({2}%)"
                                                    , resultsD.DoNotChangeTheChoiceWins, experimentsCount, resultsD.GetDoNotChangeTheChoiceWinsInPersents);
                    Console.ReadKey();

                    break;
                }

                else
                {
                    Console.WriteLine("Count of the experiments should be a number!");
                    Console.WriteLine();
                }
            }
        }

    }
}
