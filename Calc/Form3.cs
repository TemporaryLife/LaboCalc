using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Calc.Form1;

namespace Calc
{
    public partial class Form3 : Form
    {
        public static bool isDeleted = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isDeleted = false;
            int positionNumber = Convert.ToInt32(textBox1.Text);
            if (positionNumber > 0)
            {
                json_array.RemoveAt(positionNumber-1);
                all_scrolls[positionNumber-1].Dispose();
                all_positions[positionNumber - 1].Dispose();
                all_orders[positionNumber - 1].Dispose();
                isDeleted = true;
            }
            else
            {
                MessageBox.Show("Неверный ввод");
                
            }
            this.Close();
        }
    }
}
