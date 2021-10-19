using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Calc
{
    public partial class Form1 : Form
    {
        static string  path = @"C:\Users\Konstantin\source\repos\TemporaryLife\LaboCalc\goods.json", json=File.ReadAllText(path);
        static List<NumericUpDown> all_scrolls = new List<NumericUpDown>();
        static List<Goods> json_array = JsonConvert.DeserializeObject<List<Goods>>(json);
        static int n = 5;

        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            

            var json_array = JsonConvert.DeserializeObject<List<Goods>>(json);
            
            int x1 = 50;
            int x2 = 300;
            int y = 100;
            for (int i = 0; i < json_array.Count; i++)
            {
                
                if (y <= 850)
                {
                    ShowVidgets(x1, x2, y, all_scrolls, json_array[i].Weight);
                    
                    y += 50;
                }
                else
                {
                    y = 100;
                    x2 += 350;
                    x1 += 350;
                }
                
            }

            
                
            Console.ReadLine();
        }

        private void ShowVidgets(int x1, int x2,int y, List<NumericUpDown> all_scrolls, int pos_text)
        {
            NumericUpDown scroll = new NumericUpDown();
            scroll.Location = new Point(x2, y);
            scroll.Width = 40;
            all_scrolls.Add(scroll);
            Controls.Add(scroll);

            Label position = new Label();
            position.Location = new Point(x1, y);
            position.BackColor=Color.Transparent;
            position.Text = Convert.ToString(pos_text);
            Controls.Add(position);
            
            GroupBox line = new GroupBox();
            line.Location = new Point(0, y + 35);
            line.Height = 2;
            line.Width = this.Width;
            Controls.Add(line);
            
            


        }


        private void button1_Click(object sender, EventArgs e)
        {
            int res = 0;
            for (int i=0; i<all_scrolls.Count; i++)
                if (all_scrolls[i].Value == 0)
                {
                    continue;
                }
                else
                {
                    res += (int)all_scrolls[i].Value*json_array[i].Weight;
                    
                }
            MessageBox.Show($"Вес посылки: {res} грамм");
            
        }


    }
}
