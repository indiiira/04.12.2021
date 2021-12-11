using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Racionalization
    {

        private int Numerator;
        private int Denominator;

        public Racionalization(int numerator, int denominator = 1)
        {
            if (numerator == 0)
            {
                this.Numerator = 0;
                this.Denominator = 1;
            }
            else if (numerator == denominator)
            {
                this.Numerator = 1;
                this.Denominator = 1;
            }
            else if (numerator > 0 && denominator > 0 || numerator < 0 && denominator < 0)
            {
                this.Numerator = numerator;
                this.Denominator = denominator;
                Reduce1();

            }
            else if (numerator < 0 || denominator < 0)
            {
                this.Numerator = numerator;
                this.Denominator = denominator;
                Reduce1();
                this.Numerator *= -1;
            }
        }
        private void Reduce1()
        {
            this.Numerator = this.Numerator > 0 ? this.Numerator : -this.Numerator;
            this.Denominator = this.Denominator > 0 ? this.Denominator : -this.Denominator;

            int maxval = Numerator > Denominator ? Numerator : Denominator;
            for (int i = maxval; i >= 2; maxval--)
            {
                if (Numerator % maxval == 0 && Denominator % maxval == 0)
                {
                    this.Numerator /= maxval;
                    this.Denominator /= maxval;
                    break;
                }
            }
        }
        public bool IsNan
        {
            get { return Denominator != 0 ? false : true; }
        }

        public override string ToString()
        {
            return string.Format("({0} / {1})",
                Numerator, Denominator);
        }

        public static bool operator ==(Racionalization x, Racionalization y)
        {
            return x.Numerator == y.Numerator && x.Denominator == y.Denominator;
        }

        public static bool operator !=(Racionalization x, Racionalization y)
        {
            return !(x.Numerator == y.Numerator && x.Denominator == y.Denominator);
        }

        public override bool Equals(object obj)
        {
            decimal number;
            if (decimal.TryParse(obj.ToString(), out number))
            {
                return Convert.ToDecimal(Numerator) / Denominator == number;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       

        public static bool operator <(Racionalization x, Racionalization y)
        {
            return x.Numerator * y.Denominator < x.Denominator * y.Numerator;
        }

        public static bool operator >(Racionalization x, Racionalization y)
        {
            return x.Numerator * y.Denominator > x.Denominator * y.Numerator;
        }

        public static bool operator <=(Racionalization x, Racionalization y)
        {
            return x.Numerator * y.Denominator <= x.Denominator * y.Numerator;
        }

        public static bool operator >=(Racionalization x, Racionalization y)
        {
            return x.Numerator * y.Denominator >= x.Denominator * y.Numerator;
        }

        public static Racionalization operator +(Racionalization x, Racionalization y)
        {
            return new Racionalization(x.Numerator * y.Denominator + x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Racionalization operator -(Racionalization x, Racionalization y)
        {
            return new Racionalization(x.Numerator * y.Denominator - x.Denominator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Racionalization operator *(Racionalization x, Racionalization y)
        {
            return new Racionalization(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Racionalization operator /(Racionalization x, Racionalization y)
        {
            return new Racionalization(x.Numerator * y.Denominator, x.Denominator * y.Numerator);
        }

        public static Racionalization operator %(Racionalization x, Racionalization y)
        {
            return x - (Racionalization)(int)(x / y) * y;
        }

        public static Racionalization operator ++(Racionalization x)
        {
            return new Racionalization(x.Numerator + x.Denominator, x.Denominator);
        }

        public static Racionalization operator --(Racionalization x)
        {
            return new Racionalization(x.Numerator - x.Denominator, x.Denominator);
        }

        public static explicit operator Racionalization(float x)
        {
            int factor = (int)Math.Pow(10, DigitsCount(x));
            return new Racionalization(Convert.ToInt32(x * factor), factor);
        }

        public static explicit operator Racionalization(int x)
        {
            return new Racionalization(x, 1);
        }

        public static explicit operator float(Racionalization x)
        {
            return Convert.ToSingle(x.Numerator) / x.Denominator;
        }

        public static explicit operator int(Racionalization x)
        {
            return x.Numerator / x.Denominator;
        }
        //private static int NOZ(int[] maxmin)
        //{
        //    Array.Sort(maxmin);
        //    if (maxmin[1] % maxmin[0] == 0)
        //        return maxmin[1];

        //    int temp = 0;
        //    for (int i = 2; ; i++)
        //    {
        //        temp = maxmin[1] * i;
        //        if (temp % maxmin[0] == 0)
        //        {
        //            break;
        //        }
        //    }
        //    return temp;
        //}

        public static int DigitsCount(float num)
        {
            string str = num.ToString();
            if (str.Contains(","))
            {
                return str.Length - str.IndexOf(',') - 1;
            }
            else
            {
                return 0;
            }
        }
    }

}

