using System.Collections.Generic;

namespace DataLayer
{
	public interface IRepository
	{
		List<Lot> GetLots();
		void AddLot(Lot lot);
	}
}
