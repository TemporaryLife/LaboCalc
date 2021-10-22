using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public class Goods
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width  { get; set; }
        public string Name { get; set; }

        public Goods(string Name, double Weight, double Length, double Height, double Width)
        {
            this.Weight = Weight;
            this.Length = Length;
            this.Height = Height;
            this.Width = Width;
            this.Name = Name;
            
        }

        public Goods()
        {

        }

    }
}
