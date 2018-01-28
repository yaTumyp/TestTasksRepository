using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
    static class ExperimentHelper
    {

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
        private static List<bool> GetResultsList(int experimentsCount, bool chageChoice)
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


        /// <summary>
        /// Gets List<bool> with 2 false and 1 true in random indexes
        /// </summary>
        /// <returns></returns>
        private static List<bool> GetExperimentSample()
        {
            List<bool> boolList = new List<bool>() { false, false, false };

            var carIndex = GetRandom.Next(0, 3);

            boolList[carIndex] = true;

            return boolList;
        }
    }
}
