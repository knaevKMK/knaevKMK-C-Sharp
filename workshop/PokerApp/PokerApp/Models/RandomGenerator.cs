using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerApp.Models
{
    public class RandomGenerator
    {

        public static int GetRanodom(int range, List<int> missed) {
            int random = new Random().Next(range);
            if (missed.Contains(random))
            {
                return GetRanodom(range, missed);
            }
            missed.Add(random);
            return random;
        }
    }
}
