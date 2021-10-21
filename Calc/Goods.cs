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
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width  { get; set; }
        public string Name { get; set; }

        public Goods(string Name, int Weight, int Length, int Height, int Width)
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
