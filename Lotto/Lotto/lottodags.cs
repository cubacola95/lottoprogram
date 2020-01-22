using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    class lottodags
    {
        //En funktion som lagrar antal 5,6 samt 7 rätt
        public int[] antal_korrekt(int[] anv_rad, int antal_dragningar)
        {
            //En array som håller antal 5,6 och 7 rätt respektive
            int[] antal_ratt = new int[Lotto.RATT_SIZE];
            antal_ratt[0] = 0;
            antal_ratt[1] = 0;
            antal_ratt[2] = 0;

            dragning drag = new dragning();

            for (int i = 0; i < antal_dragningar; i++)
            {
                //Generera en lotto rad
                int[] lotto_rad = new int[Lotto.RAD_SIZE];
                lotto_rad = drag.generara_dragning();
                
                //Kolla om det finns fem, sex eller sju rätt
                int nr_korr = antalet_korrekta(anv_rad, lotto_rad);
                if (nr_korr == 5)
                    antal_ratt[0]++;
                else if (nr_korr == 6)
                    antal_ratt[1]++;
                else if (nr_korr == 7)
                    antal_ratt[2]++;
            }
         
            return antal_ratt;
        }

        //Kollar hur många som är korrekta av användarens rad
        int antalet_korrekta(int[] anv_rad,int[] lotto_rad)
        {
            int sum = 0;

            for(int i=0; i<Lotto.RAD_SIZE;i++)
            {
                for(int j=0; j<Lotto.RAD_SIZE; j++)
                {
                    if (anv_rad[i] == lotto_rad[j])
                    {
                        sum++;
                        break;
                    }
                }
            }

            //Print uttryck för debugging
            Console.WriteLine("" + lotto_rad[0] + " " + lotto_rad[1] + " " + lotto_rad[2] + " " + lotto_rad[3] + " " + lotto_rad[4] + " " + lotto_rad[5] + " " + lotto_rad[6]);
            Console.WriteLine("" + anv_rad[0] + " " + anv_rad[1] + " " + anv_rad[2] + " " + anv_rad[3] + " " + anv_rad[4] + " " + anv_rad[5] + " " + anv_rad[6]);
            Console.WriteLine("Antal rätt: " + sum);
            Lotto.gjorda_antal_dragningar++;
            Console.WriteLine("Antal utförda dragningar: "+Lotto.gjorda_antal_dragningar);


            //Returna int beroende på antal rätt
            if (sum == 5)
                return 5;
            else if (sum == 6)
                return 6;
            else if (sum == 7)
                return 7;
            else
                return 0;
        }
       
    }
}
