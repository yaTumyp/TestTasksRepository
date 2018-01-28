
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
                    var resultsS = GetResultsFromSameSamples(experimentsCount);
                    var resultsD = GetResultsFromDifferentSamples(experimentsCount);

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
        /// <summary>
        /// Gets List<bool> with 2 false and 1 true in random indexes
        /// </summary>
        /// <returns></returns>
        public static List<bool> GetExperimentSample()
        {
            List<bool> boolList = new List<bool>() { false, false, false };

            var carIndex = GetRandom.Next(0, 3);

            boolList[carIndex] = true;

            return boolList;
        }

        /// <summary>
        /// Gets experiment results from the same sample for bouth strategies for each experiment 
        /// </summary>
        /// <param name="experimentsCount"></param>
        /// <returns></returns>
        public static StrategiesResults GetResultsFromSameSamples(int experimentsCount)
        {

            var doNotChangeTheChoiceWins = GetResultsList(experimentsCount, false).FindAll(x => x == true).Count;

            ///For changing choice strategi in same samples all our wins become a loses and vice versa.
            var changeTheChoiceWins = experimentsCount - doNotChangeTheChoiceWins;

            return new StrategiesResults
            {
                ChangeTheChoiceWins = changeTheChoiceWins,
                DoNotChangeTheChoiceWins = doNotChangeTheChoiceWins,
                ExperimentsCount = experimentsCount
            };
        }

        /// <summary>
        /// Gets experiment results from the different samples for bouth strategies for each experiment. 
        /// </summary>
        /// <param name="experimentsCount">Сount of the experiments.</param>
        /// <returns></returns>
        public static StrategiesResults GetResultsFromDifferentSamples(int experimentsCount)
        {
            var doNotChangeTheChoiceWins = GetResultsList(experimentsCount, false).FindAll(x => x == true).Count;

            var changeTheChoiceWins = GetResultsList(experimentsCount, true).FindAll(x => x == true).Count;

            return new StrategiesResults
            {
                ChangeTheChoiceWins = changeTheChoiceWins,
                DoNotChangeTheChoiceWins = doNotChangeTheChoiceWins,
                ExperimentsCount = experimentsCount
            };
        }

        /// <summary>
        /// Gets experiment results from the random samples according the strategy for each experiment.
        /// </summary>
        /// <param name="experimentsCount">Сount of the experiments.</param>
        /// <param name="chageChoice">Strategy</param>
        /// <returns></returns>
        public static List<bool> GetResultsList(int experimentsCount, bool chageChoice)
        {
            int experimentCounter = 0;

            var resultsList = new List<bool>();

            while (experimentCounter < experimentsCount)
            {
                var experimentalSample = GetExperimentSample();
                
                var choiceIndex = GetRandom.Next(0, 3);

                /// A tricky moment.
                /// According the fact that moderator always will remove false(goat) from the sample
                ///                         we will have only one true(car) and one false(goat) in final sample.
                /// So for changeing choice strategy we can use inversion of our main choice as the result.
                /// In other words goat become a car and vice versa.
                if (chageChoice)
                {
                    resultsList.Add(!experimentalSample[choiceIndex]);
                }
                
                /// Just put chosen element in results list.
                else
                {
                    resultsList.Add(experimentalSample[choiceIndex]);
                }

                experimentCounter++;
            }

            return resultsList;
        }
    }
}
