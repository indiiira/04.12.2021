using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{ 
    class Complex
    {
        private double x;
        private double y;

        public Complex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0:0.000} + i{1};", x, y);
        }

    

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.x * b.y+ a.y * b.y) / (b.x * b.x + b.y * b.y), (a.y * b.x - a.x * b.y) / (b.x * b.x + b.y * b.y));
        }



        public static bool operator ==(Complex a, Complex b)
        {
            return a.x == b.x&& a.y == b.y;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(a.x == b.x && a.y == b.y);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.x +b.x, a.y + b.y);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.x - b.x, a.y - b.y);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.x * b.x - a.y * b.y,
                a.x * b.y + a.y * b.x);
        }
    
    public override bool Equals(object obj)
        {
            double number;
            if (obj is Complex)
            {
                return x == (obj as Complex).x && y == (obj as Complex).y;
            }
            else if (y == 0 && double.TryParse(obj.ToString(), out number))
            {
                return x == number;
            }
            else
            {
                return false;
            }
        }

    }
}
