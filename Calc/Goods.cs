using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Goods
    {
        public int Weight { get; set; }
        private int Length { get; set; }
        private int Height { get; set; }
        private int Width  { get; set; }

        public Goods(int Weight,int Length, int Height, int Width)
        {
            this.Weight = Weight;
            this.Length = Length;
            this.Height = Height;
            this.Width = Width;
        }
    }
}
