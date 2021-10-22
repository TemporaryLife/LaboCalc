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
            try
            {
                isAdded = false; 
                Goods new_item = new Goods(textBox1.Text, double.Parse(textBox2.Text),double.Parse(textBox3.Text),  //создание новой позиции
                    double.Parse(textBox4.Text), double.Parse(textBox5.Text));
                json_array.Add(new_item); //добавление в список всех позиций новой позиции
                isAdded = true; // Позиция добавлен - флаг поднят
                this.Close(); //закрытие формы добавления
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Ошибка ввода.\nПроверьте правильность введения данных (для дробных чисел используйте запятую,  а не точку).\nВсе поля должны быть заполнены",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e) //Если нажато "Отмена"
        {
            this.Close();
        }

    }
}
