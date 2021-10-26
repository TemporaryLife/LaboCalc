using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static Calc.Form2;
namespace Calc
{
    public partial class Form1 : Form
    {
        public static int x1 = 50;
        public static int x2 = 900;
        public static int y = 50;


        public static List<NumericUpDown> all_scrolls = new List<NumericUpDown>();
        public static List<Label> all_positions = new List<Label>();
        public static List<Label> all_orders = new List<Label>();


        static string  path = @"goods.json", json=File.ReadAllText(path);
        static string path2 = @"Boxes.json", json2 = File.ReadAllText(path2);
        public static List<Goods> json_array = JsonConvert.DeserializeObject<List<Goods>>(json);
        public static List<Goods> json_array2 = JsonConvert.DeserializeObject<List<Goods>>(json2);


        public static double BoxesWeight = 0;
        

        public Form1()

        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)                         //Начальная конфигурация (Внешний вид) формы
        {

            var json_array = JsonConvert.DeserializeObject<List<Goods>>(json);
            List<Goods> json_array2 = JsonConvert.DeserializeObject<List<Goods>>(json2);
            timer1.Enabled = true;
            for (int i = 0; i < json_array.Count; i++)

            {
                
                if (y <= 850)

                {
                    y += 50;
                }

                else
                {
                    y = 100;
                    x2 += 950;
                    x1 += 950;
                }

                ShowVidgets(x1, x2, y, all_scrolls, json_array[i].Name, i+1);
                
            }
            Console.ReadLine();
        }


        public void ShowVidgets(int x1, int x2, int y, List<NumericUpDown> all_scrolls, string pos_text, int pos_order)
        {
            /* Данная функция организует единицу интерфейса, т.е. создает Label с названием товара, NumUpDown с количеством этого товара
            и разграничительной линией. x1 - абсцисса метки, x2 - абсцисса счетчика позиций, y -универсальная ордината для метки и счетчика
             all_scrolls - массив для хранения всех счетчиков количества позиции(важен индекс!!!), pos_text - название позиции товара*//*
            */

            var order = new Label();
            order.Location = new Point(x1 - 40, y);
            order.Font=new Font("Arial", 12, FontStyle.Bold);

            order.Width = 30;
            order.Text = $"{Convert.ToString(pos_order)}";
            all_orders.Add(order);
            Controls.Add(order);

            NumericUpDown scroll = new NumericUpDown();
            scroll.Location = new Point(x2, y);
            scroll.Width = 40;
            all_scrolls.Add(scroll);
            Controls.Add(scroll);

            var position = new Label();
            position.Location = new Point(x1, y);
            position.Font=new Font("Arial", 12, FontStyle.Bold);
            position.BackColor = Color.Transparent;
            position.Text = Convert.ToString(pos_text);
            position.AutoSize = true;
            all_positions.Add(position);
            Controls.Add(position);

            GroupBox line = new GroupBox();
            line.Location = new Point(0, y + 35);
            line.Height = 2;
            line.Width = this.Width;
            Controls.Add(line);

        }

        private StringBuilder FindBoxToPack(List<Goods> Boxes, Goods SumOfGoodsGabarits, int n, int posCount)
        {
            double paper_napoln = 10;
            double paralon = 10;
            double BeautyWeight = 0;
            var InitialBox = Boxes[n];
            StringBuilder res = new StringBuilder();

            if (n <= 4)
            {
                if ((/*SumOfGoodsGabarits.Length <= InitialBox.Length &&*/ SumOfGoodsGabarits.Height <= InitialBox.Height
                                                                    && SumOfGoodsGabarits.Width <= InitialBox.Width))
                {
                    
                    if (posCount >=7)

                    {
                        res.Append("BeautyBox Panda ");

                        /*SumOfGoodsGabarits.Length = Math.Max(SumOfGoodsGabarits.Length, Boxes[6].Length);*/
                        SumOfGoodsGabarits.Height = Math.Max(SumOfGoodsGabarits.Height, Boxes[6].Height);
                        SumOfGoodsGabarits.Width = Math.Max(SumOfGoodsGabarits.Width, Boxes[6].Width);
                        BeautyWeight = Boxes[6].Weight;
                    }
                    else if (posCount >=3)
                    {
                        res.Append("BeautyBox ");
                        /*SumOfGoodsGabarits.Length = Math.Max(SumOfGoodsGabarits.Length, Boxes[5].Length);*/
                        SumOfGoodsGabarits.Height = Math.Max(SumOfGoodsGabarits.Height, Boxes[5].Height);
                        SumOfGoodsGabarits.Width = Math.Max(SumOfGoodsGabarits.Width, Boxes[5].Width);

                        /*SumOfGoodsGabarits = Boxes[5];*/
                        BeautyWeight = Boxes[5].Weight+paper_napoln;
                        
                    }
                }

                if (/*SumOfGoodsGabarits.Length > InitialBox.Length ||*/ SumOfGoodsGabarits.Height > InitialBox.Height
                                                                  || SumOfGoodsGabarits.Width > InitialBox.Width)
                {
  
                    return FindBoxToPack(Boxes, SumOfGoodsGabarits, n + 1, posCount);
                }
                else
                {
                    
                  

                    res.Append(Boxes[n].Name);
                    BoxesWeight = BeautyWeight+Boxes[n].Weight+paralon;  
                    if (posCount==0)
                    {
                        BoxesWeight = 0;
                        res.Clear();
                        res.Append("Нет позиций для сортировки в коробку");
                    }
                    
                    return res;
                }
            }
            else
            {

                res.Clear();
                res.Append("Нет подходящей коробки");
                return res;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            Goods resGood = new Goods(" ", 0, 0, 0, 0);
            double res = 0;
            int sum = 0;
            for (int i=0; i<all_scrolls.Count; i++)

                if (all_scrolls[i].Value == 0)
                {
                    continue;
                }

                else
                {
                    
                    res += (int)all_scrolls[i].Value*json_array[i].Weight;
                    for (int j = 0; j < (int)all_scrolls[i].Value; j++)
                    {
                        sum += 1;
                        resGood = FindGabarits(resGood, json_array[i]);
                    }

                    

                }

            resGood.Weight = res;
            MessageBox.Show($"Габариты товара: {resGood.Length}*{resGood.Height}*{resGood.Width} ({FindBoxToPack(json_array2, resGood, 0, sum)}).\n\nВес посылки: {res+BoxesWeight} грамм.\n\nВес товара(без коробок и наполнителей): {res} грамм.\n\nКоличество позиций: {sum}", "Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public Goods FindGabarits(Goods FirstGood, Goods SecondGood )                   // Алгоритм умножения габаритов

        {
            SortGabaritsOrder(FirstGood);                                               //На всякий случай расставляем габариты по порядку
            SortGabaritsOrder(SecondGood);

            Goods res_gabarit = new Goods();                                            //промежуточный объект, в который каждый раз сохраняется  суммарный габарит
            res_gabarit.Height = FirstGood.Height + SecondGood.Height;
            res_gabarit.Length = Math.Max(FirstGood.Length, SecondGood.Length);
            res_gabarit.Width = Math.Max(FirstGood.Width, SecondGood.Width);

            SortGabaritsOrder(res_gabarit);                                             //выставляем суммарный габарит по порядку

            return res_gabarit;
        }


        private void button2_Click(object sender, EventArgs e)                          //Нажатие на кнопку "Добавить позицию"
        {
            Form Form2 = new Form2();
            Form2.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)                          //Нажатие на кнопку "Отобразить"
        {
            if (isAdded)
            {

                isAdded = false;
                if (y <= 850)

                {
                    y += 50;
                    ShowVidgets(x1, x2, y, all_scrolls, json_array[json_array.Count-1].Name, json_array.Count);
                    
                    
                }

                else
                {
                    y = 100;
                    x2 += 950;
                    x1 += 950;
                    ShowVidgets(x1, x2, y, all_scrolls, json_array[json_array.Count-1].Name, json_array.Count);
                    
                }
                
            }
            
        }
        int i;
        Preview pre = new Preview();
        private void timer1_Tick(object sender, EventArgs e)                    //Блокировка кнопок для защиты "От дурака"
        {
            
            /*i++;
            if (i < 30)
            {

                pre.Show();
            }*/
            /*else
            {
                pre.Close();
                this.Show();
            }*/
            if (isAdded )
            {
                button3.Enabled = true;
                button2.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                button3.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = true;

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  //Сохранение изменений в файл при закрытии формы
        {
            string str = JsonConvert.SerializeObject(json_array);
            File.WriteAllText(path,str);
        }

        private void button4_Click(object sender, EventArgs e)                  //Нажатие на кнопку "Удалить позицию"
        {
            Form Form3 = new Form3();
            Form3.Show();
        }






        public void SortGabaritsOrder(Goods stuff)                              //Сортировка габаритов по возрастанию Length --> Height --> Width
        {


 
            double a = stuff.Height;
            double b = stuff.Width;
            double min, med, max, bufer;


            if (a <= b)
            {
                min = a;
                max = b;
            }
            else
            {
                min = b;
                max = a;
            }


            /*if (a <= b && a <= c)                                               //нахождение максимального, среднего и минимального габарита для товара
            {
                min = a;
                if (b < c)
                {
                    med = b;
                    max = c;
                }
                else
                {
                    med = c;
                    max = b;
                }
            }
            
            else if (a <= b && a >= c)
            {
                min = c;
                if (a < b)
                {
                    med = a;
                    max = b;
                }
                else
                {
                    med = b;
                    max = a;
                }

            }

            else
            {
                min = b;
                if (a < c)
                {
                    med = a;
                    max = c;
                    
                }
                else
                {
                    med = c;
                    max = a;
                }
            }*/
            
/*            stuff.Length = min;*/
            stuff.Height = min;
            stuff.Width = max;

        }
        

    }
}
