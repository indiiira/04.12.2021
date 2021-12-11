using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Build
    {
		private int index;
		private double high;
		private int storeys;
		private int aparts;
		private int entrances;

		static int indexer = 0;
		static List<int> indexes = new List<int>();

		public Build()
		{
			index = indexer++;
		}
		public Build(double High, int Storeys, int Aparts, int Entrances)
		{
			index = indexer++;
			this.High = High;
			this.Storeys = Storeys;
			this.Aparts = Aparts;
			this.Entrances = Entrances;
		}
		public int Index
		{
			get => index;
			set
			{
				if (!indexes.Contains(Index))
				{
					if (value > 0)
					{
						index = value;
						indexes.Add(Index);
					}
					else
					{
						throw new ArgumentOutOfRangeException("Значение может быть только неотрицательным числом.");
					}
				}
				else
				{
					throw new Exception("Экземляр с таким номером уже существует.");
				}
			}
		}
		public double High
		{
			get => high;
			set
			{
				if (value > 0)
				{
					high = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Значение может быть только положительным числом.");
				}
			}

		}
		public int Storeys
		{
			get => storeys;
			set
			{
				if (value > 0)
				{
					storeys = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Значение может быть только натуральным числом.");
				}
			}

		}
		public int Aparts
		{
			get => aparts;
			set
			{
				if (value > 0)
				{
					aparts = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Значение может быть только натуральным числом.");
				}
			}
		}
		public int Entrances
		{
			get => entrances;
			set
			{
				if (value > 0)
				{
					entrances = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Значение может быть только натуральным числом.");
				}
			}
		}
		public double GetHighOfStorey(int NumberOfStorey)
		{
			if (NumberOfStorey <= storeys && NumberOfStorey > 0)
			{
				return high / storeys * NumberOfStorey;
			}
			else
			{
				throw new ArgumentOutOfRangeException("Такого номера этажа не существует.");
			}
		}
		public int GetApartNumberOfEntrance()
		{
			return aparts / entrances;
		}
		public int GetApartNumberOfStorey()
		{
			return GetApartNumberOfEntrance() / storeys;
		}

        public static implicit operator Build(int v)
        {
            throw new NotImplementedException();
        }
    }
}

