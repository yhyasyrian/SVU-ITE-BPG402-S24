using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Point
    {
        /**
         * property for access
         */
        public int X = 0;
        public int Y = 0;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        // to east convert object to strign
        public override string ToString()
        {
            return String.Format("({0},{1})",this.X,this.Y);
        }
        /**
         * return true equal current point (this) large or equal than secondary point (SecondaryPoint)
         */
        public bool CompareX(Point SecondaryPoint)
        {
            return SecondaryPoint.X <= X;
        }
        public bool CompareY(Point SecondaryPoint)
        {
            return SecondaryPoint.Y <= Y;
        }
    }
}
