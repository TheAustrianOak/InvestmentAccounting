using Models.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstractions
{
	public interface IShareService
	{
		int GetTotalAvailableShares();
		void AddLot(int shares, decimal price);
		ShareCalculationModel CalculateShares(int sharesSold, decimal pricePerShare);
	}
}
