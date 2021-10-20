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
    
    public partial class Form2 : Form
    {
        public static bool isAdded; //Флаг проверки добавлена ли позиция для отображения
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)// Если нажато "Добавить"
        {
            isAdded = false; 
            Goods new_item = new Goods(int.Parse(textBox2.Text),int.Parse(textBox3.Text),  //создание новой позиции
                int.Parse(textBox4.Text), int.Parse(textBox5.Text));
            json_array.Add(new_item); //добавление в список всех позиций новой позиции
            isAdded = true; // Позиция добавлен - флаг поднят
            this.Close(); //закрытие формы добавления
            
            
        }

        private void button2_Click(object sender, EventArgs e) //Если нажато "Отмена"
        {
            this.Close();
        }

    }
}
