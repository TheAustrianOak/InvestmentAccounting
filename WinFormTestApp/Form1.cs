using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTestApp
{
	public partial class Form1 : Form
	{
		private List<Lot> lots;

		public Form1()
		{
			InitializeComponent();
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

		private void buttonCalculate_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxSharesSold.Text, out int sharesSold) &&
				decimal.TryParse(textBoxPricePerShare.Text, out decimal pricePerShare))
			{
				if (sharesSold <= 0)
				{
					MessageBox.Show("The number of shares sold must be greater than 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				int totalAvailableShares = CalculateTotalAvailableShares();
				if (sharesSold > totalAvailableShares)
				{
					MessageBox.Show($"You cannot sell more shares than you have available. You have {totalAvailableShares} shares available.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				int remainingShares = CalculateRemainingShares(sharesSold);
				decimal costBasisSold = CalculateCostBasisSold(sharesSold);
				decimal costBasisRemaining = CalculateCostBasisRemaining();
				decimal totalProfit = CalculateTotalProfit(sharesSold, pricePerShare, costBasisSold);

				labelRemainingShares.Text = $"Remaining Shares: {remainingShares}";
				labelCostBasisSold.Text = $"Cost Basis Sold: {costBasisSold:C}";
				labelCostBasisRemaining.Text = $"Cost Basis Remaining: {costBasisRemaining:C}";
				labelTotalProfit.Text = $"Total Profit: {totalProfit:C}";
			}
			else
			{
				MessageBox.Show("Please enter valid numbers for shares sold and price per share.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private int CalculateTotalAvailableShares()
		{
			return lots.Sum(lot => lot.Shares);
		}

		private void buttonAddLot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxNewShares.Text, out int newShares) &&
				decimal.TryParse(textBoxNewPrice.Text, out decimal newPrice))
			{
				lots.Add(new Lot(newShares, newPrice));
				MessageBox.Show("New lot added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				textBoxNewShares.Clear();
				textBoxNewPrice.Clear();
			}
			else
			{
				MessageBox.Show("Please enter valid numbers for new shares and price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private int CalculateRemainingShares(int sharesSold)
		{
			int totalShares = 0;
			foreach (var lot in lots)
			{
				totalShares += lot.Shares;
			}
			return totalShares - sharesSold;
		}

		private decimal CalculateCostBasisSold(int sharesSold)
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

		private decimal CalculateCostBasisRemaining()
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

		private class Lot
		{
			public int Shares { get; set; }
			public decimal Price { get; }

			public Lot(int shares, decimal price)
			{
				Shares = shares;
				Price = price;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
