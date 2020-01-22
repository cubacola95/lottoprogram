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
        //Använder static och sync object för att uppnå fullt randomiserade tal samt synkronisering
        private static Random rando;
        private static object Sync_Sak = new object();

        /*private static void Start_Rand_Num()
        {
            rando = new Random();
        }*/

        //Randomisera tal
        private static int Gen_rand_num()
        {
            lock (Sync_Sak)
            {
                if (rando == null)
                {
                    rando = new Random();
                }

                //Randomiserat tal mellan 1 och 35, need +1 to max
                return rando.Next(Lotto.MIN_RAND, Lotto.MAX_RAND+1);
            }
        }

        //En funktion som lagrar antal 5,6 samt 7 rätt på en rad
        public int[] antal_korrekt(int[] anv_rad, int antal_dragningar)
        {
            //En array som håller antal 5,6 och 7 rätt respektive
            int[] antal_ratt = new int[Lotto.RATT_SIZE];
            antal_ratt[0] = 0;
            antal_ratt[1] = 0;
            antal_ratt[2] = 0;

            for (int i = 0; i < antal_dragningar; i++)
            {
                //Generera en lotto rad
                int[] lotto_rad = new int[Lotto.RAD_SIZE];
                lotto_rad = generara_dragning();
                
                //Kolla om det finns fem, sex eller sju rätt
                int nr_korr = granskning(anv_rad, lotto_rad);
                if (nr_korr == 5)
                    antal_ratt[0]++;
                else if (nr_korr == 6)
                    antal_ratt[1]++;
                else if (nr_korr == 7)
                    antal_ratt[2]++;
            }
         
            return antal_ratt;
        }

        //Kollar hur många som är korrekta av användarens rad, notera att alla kommentarer är för debugging syfte(Bra för er handledare)
        int granskning(int[] anv_rad,int[] lotto_rad)
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

            //Här under finns det många bortkommenterade consol write lines, tänkte att de kunde vara användbara för er handledare

            //Console.WriteLine("" + lotto_rad[0] + " " + lotto_rad[1] + " " + lotto_rad[2] + " " + lotto_rad[3] + " " + lotto_rad[4] + " " + lotto_rad[5] + " " + lotto_rad[6]);
            //Console.WriteLine("" + anv_rad[0] + " " + anv_rad[1] + " " + anv_rad[2] + " " + anv_rad[3] + " " + anv_rad[4] + " " + anv_rad[5] + " " + anv_rad[6]);
            //Console.WriteLine("Antal rätt: " + sum);

            //Ökar antal gjorda draggningar så man kan se i consolen när vinster gjordes hände, ganska oanvändbar jusst nu.
            Lotto.gjorda_antal_dragningar++;
            
            //Console.WriteLine("Antal utförda dragningar: "+Lotto.gjorda_antal_dragningar);


            //Returna int beroende på antal rätt. 
            if (sum == 5)
            {
                /*Console.WriteLine("Fem rätt dragning nr: " + Lotto.gjorda_antal_dragningar);
                Console.WriteLine("" + lotto_rad[0] + " " + lotto_rad[1] + " " + lotto_rad[2] + " " + lotto_rad[3] + " " + lotto_rad[4] + " " + lotto_rad[5] + " " + lotto_rad[6]);
               */

                return 5;
            }
            else if (sum == 6)
            {
                /*Console.WriteLine("sex rätt dragning nr: " + Lotto.gjorda_antal_dragningar);
                Console.WriteLine("" + lotto_rad[0] + " " + lotto_rad[1] + " " + lotto_rad[2] + " " + lotto_rad[3] + " " + lotto_rad[4] + " " + lotto_rad[5] + " " + lotto_rad[6]);
               */

                return 6;
            }
            else if (sum == 7)
            {
                /*Console.WriteLine("sju rätt dragning nr: " + Lotto.gjorda_antal_dragningar);
                Console.WriteLine("" + lotto_rad[0] + " " + lotto_rad[1] + " " + lotto_rad[2] + " " + lotto_rad[3] + " " + lotto_rad[4] + " " + lotto_rad[5] + " " + lotto_rad[6]);
                */

                return 7;
            }
            else
                return 0;
        }

        
        //Metod vars syfte är att generera en dragning med 7 lotto nummer
        public int[] generara_dragning()
        {
            int[] lotto_dragning = new int[7];

            bool flag = false;
     
            //Generera en array med 7 heltal fylld med unika nummer
            for (int i = 0; i < 7; i++)
            {
                while (flag == false)
                {
                    //Generera ett radomiserat tal och lagra i rand
                    int temp = Gen_rand_num();
                    flag = true;

                    //Kolla om det nya numret är unikt
                    if (lotto_dragning.Contains(temp))
                    {
                        //Ändra flagan till false om talet ej är unikt vilket kommer generera ett nytt randomiserat tal
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
