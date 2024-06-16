using BusinessLayer.Services.Abstractions;
using DataLayer;
using Models.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public class ShareService : IShareService
	{
		private readonly IRepository repository;

		public ShareService(IRepository repository)
		{
			this.repository = repository;
		}

		public int GetTotalAvailableShares()
		{
			return repository.GetLots().Sum(lot => lot.Shares);
		}

		public void AddLot(int shares, decimal price)
		{
			repository.AddLot(new Lot(shares, price));
		}

		public ShareCalculationModel CalculateShares(int sharesSold, decimal pricePerShare)
		{
			var lots = repository.GetLots();
			int totalShares = GetTotalAvailableShares();
			if (sharesSold > totalShares)
			{
				throw new InvalidOperationException($"You cannot sell more shares than you have available. You have {totalShares} shares available.");
			}

			int remainingShares = CalculateRemainingShares(lots, sharesSold);
			decimal costBasisSold = CalculateCostBasisSold(lots, sharesSold);
			decimal costBasisRemaining = CalculateCostBasisRemaining(lots);
			decimal totalProfit = CalculateTotalProfit(sharesSold, pricePerShare, costBasisSold);

			ShareCalculationModel shareCalculations = new ShareCalculationModel
			{
				RemainingShares = remainingShares,
				CostBasisSold = costBasisSold,
				CostBasisRemaining = costBasisRemaining,
				TotalProfit = totalProfit
			};
			return shareCalculations;
		}

		private int CalculateRemainingShares(List<Lot> lots, int sharesSold)
		{
			return lots.Sum(lot => lot.Shares) - sharesSold;
		}

		private decimal CalculateCostBasisSold(List<Lot> lots, int sharesSold)
		{
			int sharesToSell = sharesSold;
			decimal totalCost = 0;

			foreach (var lot in lots)
			{
				if (sharesToSell <= lot.Shares)
				{
					totalCost += sharesToSell * lot.Price;
					lot.Shares -= sharesToSell;
					break;
				}
				else
				{
					totalCost += lot.Shares * lot.Price;
					sharesToSell -= lot.Shares;
					lot.Shares = 0;
				}
			}

			return totalCost / sharesSold;
		}

		private decimal CalculateCostBasisRemaining(List<Lot> lots)
		{
			int totalShares = 0;
			decimal totalCost = 0;

			foreach (var lot in lots)
			{
				totalShares += lot.Shares;
				totalCost += lot.Shares * lot.Price;
			}

			return totalShares > 0 ? totalCost / totalShares : 0;
		}

		private decimal CalculateTotalProfit(int sharesSold, decimal pricePerShare, decimal costBasisSold)
		{
			return sharesSold * (pricePerShare - costBasisSold);
		}
	}
}
