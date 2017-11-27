using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int drama = 0;
        double totalDamage = 0;
        double scaling = 1.0;
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "Welcome to Silktail's damage calculator Combos should be inputted in the following manner \"initial scaling value,hit,hit...\"  hits should be formatted as such.  if the hit adds drama input \"damage: drama\" otherwise just use \"damage\"  the initial scaling value is dependant on team sizes and counter hit \n\nif there are scaling values I do not take into account (such as dhc or tag) after damage and drama you may place a ^ followed by a decimal value to auto set the scaling value, a * followed by a decimal value to multiply a decimal by the scalar and a $ followed by a decimal value to set a minimum scaling for this move...\nhave fun";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Text = totalDamage.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drama = 0;
            int tempdrama = 0;
            totalDamage = 0;
            double damage = 0;
            String[] combo = textBox1.Text.Split(',');
            double.TryParse(combo[0], out scaling);
            for (int i = 1; i < combo.Length; i++)
            {
                if (i > 3)//set the scaling for this hit
                {
                    if (scaling > .2)
                        scaling *= .875;

                }
                double.TryParse(combo[i].Split(':')[0], out damage);
                if (damage >= 1000 && scaling < .275)//calculate hits damage
                {
                    damage *= .275;
                }
                else
                {
                    damage *= scaling;
                }
                if (drama >= 240)
                {
                    damage *= .5;
                }
                if (combo[i].Split(':').Length > 1)//is there drama
                {
                    int.TryParse(combo[i].Split(':')[1], out tempdrama);
                    drama += tempdrama;
                    tempdrama = 0;//add to dra,a
                }
                if (combo[i].Split('^').Length > 1)
                {
                    double.TryParse(combo[i].Split('^')[1], out scaling);
                }
                else if (combo[i].Split('*').Length > 1)
                {
                    double scalar = 1;
                    double.TryParse(combo[i].Split('*')[1], out scalar);
                    scaling *= scalar;
                }
                else if (combo[i].Split('$').Length > 1)
                {
                    double scalar = 1;
                    double.TryParse(combo[i].Split('$')[1], out scalar);
                    if (scaling < scalar)
                    {
                        scaling = scalar;
                    }
                }
                totalDamage += damage;//add the damage
                textBox2.Text = "Damage = "+totalDamage.ToString()+" Drama = "+drama;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Welcome to silktails damage calculator Combos should be inputted in the following manner \"initial scaling value,hit,hit...\"  hits should be formatted as such.  if the hit adds drama input \"damage: drama\" otherwise just use \"damage\"  the initial scaling value is dependant on team sizes and counter hit \n\nif there are scaling values I do not take into account (such as dhc or tag) after damage and drama you may place a ^followed by a decimal value to auto set the scaling value or *followed by a decimal value to multiply a decimal by the scalar...\nhave fun";

        }
    }
}
