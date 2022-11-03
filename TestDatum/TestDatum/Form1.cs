using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDatum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        List<string> kolekce = new List<string>();
        int pocet = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (pocet > 0) button2.Visible = true;
            DateTime narozeni = dateTimePicker1.Value;
            int mesic = narozeni.Month;
            int datum = narozeni.Day;
            int rok = narozeni.Year;

            string rokpomoc = rok.ToString();
            rokpomoc = rokpomoc.Remove(0, 2);
            string datumpomoc;
            string mesicpomoc;
            if (radioButton1.Checked)
            {
                mesic += 50;
                kolekce.Add("Žena");
            }
            else kolekce.Add("Muž");
            kolekce.Add(narozeni.ToString());
            if (datum < 10)
            {
                datumpomoc = "0";
                datumpomoc += datum.ToString();
            }
            else datumpomoc = datum.ToString();
            if (mesic < 10)
            {
                mesicpomoc = "0";
                mesicpomoc += mesic.ToString();
            }
            else mesicpomoc = mesic.ToString();
            Random rng = new Random();
            int c = rng.Next(100, 1000);
            int a = rng.Next(0, 10);
            string delitelnost = rokpomoc + mesicpomoc + datumpomoc+c.ToString()+a.ToString();
            ulong cislo = Convert.ToUInt64(delitelnost);
            while(cislo % 11 != 0)
            {
                    delitelnost = delitelnost.Remove(9);
                    a = rng.Next(0, 10);
                    delitelnost += a.ToString();
                    cislo = Convert.ToUInt64(delitelnost);
            }
            maskedTextBox2.Text = delitelnost;
            maskedTextBox1.Text = delitelnost;
            pocet++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pocetmuzu = 0;
            int pocetzen = 0;
            DateTime nejstarsi = DateTime.Now;
            DateTime nejmladsi = new DateTime();
            foreach(string c in kolekce)
            {
                if (c == "Muž") pocetmuzu++;
                else if (c == "Žena") pocetzen++;
                else
                {
                    if (nejstarsi > Convert.ToDateTime(c)) nejstarsi = Convert.ToDateTime(c);
                    if (nejmladsi < Convert.ToDateTime(c)) nejmladsi = Convert.ToDateTime(c);
                }
            }
            MessageBox.Show("Počet mužů: " + pocetmuzu.ToString() + ", počet žen:" + pocetzen.ToString()) ;
            TimeSpan rozdil = nejstarsi - nejmladsi;
            double roky = (rozdil.Days/365.25)*(-1);
            MessageBox.Show("Rozdíl mezi nejstarším a nejmladším je: " + roky.ToString() + " let");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            radioButton1.Checked = true;
        }
    }
}
