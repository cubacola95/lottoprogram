using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Lotto : Form
    {
        public const int MAX_RAND= 35;
        public const int MIN_RAND = 1;

        public const int RAD_SIZE = 7;
        public const int RATT_SIZE = 3;

        public static int gjorda_antal_dragningar = 0;

        public Lotto()
        {
            InitializeComponent();
        }

        private void Lotto_Load(object sender, EventArgs e)
        {

        }

        private void rad_label_Click(object sender, EventArgs e)
        {

        }

        private void Start_Knapp_Click(object sender, EventArgs e)
        {
            gjorda_antal_dragningar = 0;
            draw_box.Text = gjorda_antal_dragningar.ToString();
            //If satsen kollar så att alla boxar har blivit skrivna i 
            if (String.IsNullOrEmpty(Input_Rad_1.Text) || String.IsNullOrEmpty(Input_Rad_2.Text) || String.IsNullOrEmpty(Input_Rad_3.Text) || String.IsNullOrEmpty(Input_Rad_4.Text) || String.IsNullOrEmpty(Input_Rad_5.Text) || String.IsNullOrEmpty(Input_Rad_6.Text) || String.IsNullOrEmpty(Input_Rad_7.Text) || String.IsNullOrEmpty(number_dragningar_box.Text))
            {
                MessageBox.Show("Alla boxar måste vara ifyllda!");
            }
            else
            {
                //Gör knappen otryckbar under tiden som programmet exekverar
                Start_Knapp.Enabled = false;

                //Array som lagrar användarens rad
                int[] input_array = new int[RAD_SIZE];                          

                //Sätt in all input i en array
                Int32.TryParse(Input_Rad_1.Text, out input_array[0]);
                Int32.TryParse(Input_Rad_2.Text, out input_array[1]);
                Int32.TryParse(Input_Rad_3.Text, out input_array[2]);
                Int32.TryParse(Input_Rad_4.Text, out input_array[3]);
                Int32.TryParse(Input_Rad_5.Text, out input_array[4]);
                Int32.TryParse(Input_Rad_6.Text, out input_array[5]);
                Int32.TryParse(Input_Rad_7.Text, out input_array[6]);

                //Kolla om listan är unik!
                int unik = input_array.Distinct().Count();
                if (unik == input_array.Count())
                {
                    int[] korrekt_array = new int[RATT_SIZE];
                    int antal_dragningar = 0;
                    //Lagra antal draggningar i en int
                    Int32.TryParse(number_dragningar_box.Text, out antal_dragningar);

                    lottodags lotto = new lottodags();      
                    korrekt_array = lotto.antal_korrekt(input_array, antal_dragningar);

                    //Vissa antalet rätt
                    draw_box.Text = gjorda_antal_dragningar.ToString();
                    five_right_box.Text = korrekt_array[0].ToString();
                    six_right_box.Text = korrekt_array[1].ToString();
                    seven_right_box.Text = korrekt_array[2].ToString();

                }
                else
                    MessageBox.Show("Alla tal måste vara unika!");
                
                Start_Knapp.Enabled = true;
            }
        }

        private void Input_Rad_1_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_1.Text, out int_rad))
            {
                if(int_rad> MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_1.Text = "";
            }
            else
            {        
                Input_Rad_1.Text = "";
            }
        }

        private void Input_Rad_2_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_2.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_2.Text = "";
            }
            else
            {
                Input_Rad_2.Text = "";
            }

        }

        private void Input_Rad_3_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_3.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_3.Text = "";
            }
            else
            {
                Input_Rad_3.Text = "";
            }
        }

        private void Input_Rad_4_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_4.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_4.Text = "";
            }
            else
            {
                Input_Rad_4.Text = "";
            }

        }

        private void Input_Rad_5_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_5.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_5.Text = "";
            }
            else
            {
                Input_Rad_5.Text = "";
            }
        }

        private void Input_Rad_6_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_6.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_6.Text = "";
            }
            else
            {
                Input_Rad_6.Text = "";
            }
        }

        private void Input_Rad_7_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(Input_Rad_7.Text, out int_rad))
            {
                if (int_rad > MAX_RAND || int_rad < MIN_RAND)
                    Input_Rad_7.Text = "";
            }
            else
            {
                Input_Rad_7.Text = "";
            }
        }

        private void number_dragningar_box_TextChanged(object sender, EventArgs e)
        {
            int int_rad = 0; //Används för att ta emot inskrivna strängen

            //Kollar om du skriver in siffror och om siffrorna är mellan 1 och 35!
            if (Int32.TryParse(number_dragningar_box.Text, out int_rad))
            {

            }
            else
                number_dragningar_box.Text = "";
        }
    }
}
