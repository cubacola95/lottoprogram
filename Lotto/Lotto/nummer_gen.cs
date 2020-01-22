using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class nummer_gen
    {
        public int rand_num()
        {
            //Create a random nummber between 1 and 36
            Random rand = new Random();

            return rand.Next(Lotto.MIN_RAND, Lotto.MAX_RAND);
        }
    }
}
