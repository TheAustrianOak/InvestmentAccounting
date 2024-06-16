using System.Collections.Generic;

namespace DataLayer
{
	public class LotRepository : IRepository
	{
		private List<Lot> lots;

		public LotRepository()
		{
			InitializeLots();
		}

		private void InitializeLots()
		{
			lots = new List<Lot>
			{
				new Lot(100, 20),
				new Lot(150, 30),
				new Lot(120, 10)
			};
		}

		public List<Lot> GetLots()
		{
			return lots;
		}

		public void AddLot(Lot lot)
		{
			lots.Add(lot);
		}
	}
}
