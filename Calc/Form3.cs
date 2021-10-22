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
        public static int positionNumber;
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
            try
            {
                isDeleted = false;
                positionNumber = Convert.ToInt32(textBox1.Text);
                if (positionNumber > 0)
                {

                    all_scrolls[positionNumber - 1].Dispose();
                    all_positions[positionNumber - 1].Dispose();
                    all_orders[positionNumber - 1].Dispose(); //Удаление виджета с формы

                    json_array.RemoveAt(positionNumber - 1); //Удаление стертой позиции из списков
                    all_orders.RemoveAt(positionNumber - 1);
                    all_scrolls.RemoveAt(positionNumber - 1);
                    all_positions.RemoveAt(positionNumber - 1);
                    isDeleted = true;
                }
                else
                {
                    MessageBox.Show("Нельзя вводить числа меньше 1.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (isDeleted)
                {
                    y -= 50; // Если до этого был удален элемент, новый созданный займет позицию последнего (Смещение)
                    isDeleted = false;
                    int _x1, _x2, _y; // переменные для работы с удалением позиций
                    _x1 = all_positions[all_positions.Count - 1].Location
                        .X; //Итерации начнутся с верхнего элемента для смещения позиций после удаления
                    _x2 = all_scrolls[all_scrolls.Count - 1].Location.X;
                    _y = all_scrolls[all_scrolls.Count - 1].Location.Y;

                    for (int i = json_array.Count - 1; i >= positionNumber - 1; i--)

                    {

                        if (_y > 100)

                        {
                            _y -= 50;
                        }


                        else
                        {
                            _y = 900;
                            _x2 -= 950;
                            _x1 -= 950;


                        }

                        all_scrolls[i].Location = new Point(_x2, _y);
                        all_positions[i].Location = new Point(_x1, _y);
                        all_orders[i].Location = new Point(_x1 - 40, _y);
                        all_orders[i].Text = $"{Convert.ToInt32(all_orders[i].Text) - 1}";

                    }
                }

                this.Refresh();
                this.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Позиции с таким номером не существует.", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректный ввод. Введите целое число, соответствующее позиции удаляемого товара.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
