using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHall
{
    public class StrategiesResults
    {
        public int ChangeTheChoiceWins;
        public int DoNotChangeTheChoiceWins;
        public int ExperimentsCount;

        public int GetChangeTheChoiceWinsInPersents
        {
            get
            {
                return (int)Math.Round((double)(100 * ChangeTheChoiceWins) / ExperimentsCount);
            }
        }

        public int GetDoNotChangeTheChoiceWinsInPersents
        {
            get
            {
                return (int)Math.Round((double)(100 * DoNotChangeTheChoiceWins) / ExperimentsCount);
            }

        }

    }
}
