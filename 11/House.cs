using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
   public class House
    {

		public House(uint height, uint levels, uint countEntrances, uint countFlats)
		{
			_guid = Guid.NewGuid();
			_levels = levels;
			_height = height;
			_countEntrances = countEntrances;
			_countFlats = countFlats;
		}
		public uint GetAvgFlatsOnLevel()
		{
			return GetAvgFlatsInEntarances() / _levels;
		}
		public uint GetAvgFlatsInEntarances()
		{
			return _countFlats / _countEntrances;
		}

		public uint GetHeightLevel()
		{
			return _height / _levels;
		}
		public void GetInfo()
		{
			Console.WriteLine(string.Format("Уникальный номер дома : {0}, высота дома : {1}, количество этажей в доме : {2}, количество квартир : {3}, количество подъездов {4}", new object[]
			{
				_guid,
				_height,
				_levels,
				_countFlats,
				_countEntrances
			}));
		}

		private Guid _guid;
		private uint _height;
		private uint _levels;
		private uint _countFlats;
		private uint _countEntrances;

	}
}
