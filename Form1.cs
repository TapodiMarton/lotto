using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lotto
{
    public partial class Form1 : Form
    {
        List<Sorsolas> sorsolasok = new List<Sorsolas>();
        List<Szam> szamok = new List<Szam>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("lotto.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolas_object = new Sorsolas(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                sorsolasok.Add(sorsolas_object);
            }

            //2. Feladat:
            int db = 0;
            for (int i = 1; i < 46; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if (i == item.szam1 || i == item.szam2 || i == item.szam3 || i == item.szam4 || i == item.szam5 || i == item.szam6)
                        db++;
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db = 0;
            }

            int min_db = int.MaxValue;
            int min_szam = 0;



            //3.feladat
            int paratlan = 0;
            foreach (var item in sorsolasok)
            {
                if (item.szam1 % 2 == 0) paratlan++;
                if (item.szam2 % 2 == 0) paratlan++;
                if (item.szam3 % 2 == 0) paratlan++;
                if (item.szam4 % 2 == 0) paratlan++;
                if (item.szam5 % 2 == 0) paratlan++;
                if (item.szam6 % 2 == 0) paratlan++;
            }
            label5.Text = "Páratlan számok: " + paratlan.ToString() + " db.";


            foreach (var item in szamok)
            {
                if (item.db < min_db)
                {
                    min_db = item.db;
                    min_szam = item.szam;
                }
                //4. Feladat  1
                if (item.szam == 1)
                    label3.Text = $"1-es: {item.db} db";
                //5. Feladat  3
                if (item.szam == 3)
                    label4.Text = $"3-as: {item.db} db";

            }
            label2.Text = $"Legkevesebszer kihúzva: {min_szam}: {min_db}";

            //6. Feladat
            foreach (var item in szamok)
                dataGridView1.Rows.Add(item.szam, item.db);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in sorsolasok)
                if (numericUpDown1.Value == item.het)
                    label1.Text = $"Feladat1: {item.het}. hét: {item.szam1},{item.szam2},{item.szam3},{item.szam4},{item.szam5},{item.szam6}";
        }
    }
}