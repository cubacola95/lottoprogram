using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    public class dragning
    {
        public int [] generara_dragning()
        {
            int[] lotto_dragning = new int[7];
            nummer_gen rando = new nummer_gen();
            bool flag = false;

            //Generera en array med 7 heltal fylld med unika nummer
            for (int i=0; i<7;i++)
            {      
                while (flag == false)
                {
                    //Generera ett radomiserat tal och lagra i rand
                    int temp = rando.rand_num();
                    flag = true;
                    
                    if (lotto_dragning.Contains(temp))
                    {
                        //Ändra flagan till false vilket kommer generera ett nytt randomiserat tal
                        flag = false;
                    }
                    else
                        lotto_dragning[i] = temp;     
                }               
                flag = false;
            }
            return lotto_dragning;
        }

    }
}
