using BusinessLayer.Services.Abstractions;
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
		private readonly IShareService shareManager;

		public Form1(IShareService shareManager)
		{
			this.shareManager = shareManager;
			InitializeComponent();
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

				int totalAvailableShares = shareManager.GetTotalAvailableShares();
				if (sharesSold > totalAvailableShares)
				{
					MessageBox.Show($"You cannot sell more shares than you have available. You have {totalAvailableShares} shares available.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				try
				{
					var result = shareManager.CalculateShares(sharesSold, pricePerShare);

					labelRemainingShares.Text = $"Remaining Shares: {result.RemainingShares}";
					labelCostBasisSold.Text = $"Cost Basis Sold: {result.CostBasisSold:C}";
					labelCostBasisRemaining.Text = $"Cost Basis Remaining: {result.CostBasisRemaining:C}";
					labelTotalProfit.Text = $"Total Profit: {result.TotalProfit:C}";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Please enter valid numbers for shares sold and price per share.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void buttonAddLot_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBoxNewShares.Text, out int newShares) &&
				decimal.TryParse(textBoxNewPrice.Text, out decimal newPrice))
			{
				shareManager.AddLot(newShares, newPrice);
				MessageBox.Show("New lot added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				textBoxNewShares.Clear();
				textBoxNewPrice.Clear();
			}
			else
			{
				MessageBox.Show("Please enter valid numbers for new shares and price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
