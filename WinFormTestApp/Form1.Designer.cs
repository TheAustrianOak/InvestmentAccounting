namespace WinFormTestApp
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxSharesSold;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPricePerShare;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.Label labelRemainingShares;
		private System.Windows.Forms.Label labelCostBasisSold;
		private System.Windows.Forms.Label labelCostBasisRemaining;
		private System.Windows.Forms.Label labelTotalProfit;

		// New controls for adding lots
		private System.Windows.Forms.Label labelNewShares;
		private System.Windows.Forms.TextBox textBoxNewShares;
		private System.Windows.Forms.Label labelNewPrice;
		private System.Windows.Forms.TextBox textBoxNewPrice;
		private System.Windows.Forms.Button buttonAddLot;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxSharesSold = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPricePerShare = new System.Windows.Forms.TextBox();
			this.buttonCalculate = new System.Windows.Forms.Button();
			this.labelRemainingShares = new System.Windows.Forms.Label();
			this.labelCostBasisSold = new System.Windows.Forms.Label();
			this.labelCostBasisRemaining = new System.Windows.Forms.Label();
			this.labelTotalProfit = new System.Windows.Forms.Label();
			this.labelNewShares = new System.Windows.Forms.Label();
			this.textBoxNewShares = new System.Windows.Forms.TextBox();
			this.labelNewPrice = new System.Windows.Forms.Label();
			this.textBoxNewPrice = new System.Windows.Forms.TextBox();
			this.buttonAddLot = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Shares Sold:";
			// 
			// textBoxSharesSold
			// 
			this.textBoxSharesSold.Location = new System.Drawing.Point(104, 12);
			this.textBoxSharesSold.Name = "textBoxSharesSold";
			this.textBoxSharesSold.Size = new System.Drawing.Size(100, 20);
			this.textBoxSharesSold.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Price Per Share:";
			// 
			// textBoxPricePerShare
			// 
			this.textBoxPricePerShare.Location = new System.Drawing.Point(104, 38);
			this.textBoxPricePerShare.Name = "textBoxPricePerShare";
			this.textBoxPricePerShare.Size = new System.Drawing.Size(100, 20);
			this.textBoxPricePerShare.TabIndex = 3;
			// 
			// buttonCalculate
			// 
			this.buttonCalculate.Location = new System.Drawing.Point(15, 64);
			this.buttonCalculate.Name = "buttonCalculate";
			this.buttonCalculate.Size = new System.Drawing.Size(189, 23);
			this.buttonCalculate.TabIndex = 4;
			this.buttonCalculate.Text = "Calculate";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
			// 
			// labelRemainingShares
			// 
			this.labelRemainingShares.AutoSize = true;
			this.labelRemainingShares.Location = new System.Drawing.Point(12, 100);
			this.labelRemainingShares.Name = "labelRemainingShares";
			this.labelRemainingShares.Size = new System.Drawing.Size(96, 13);
			this.labelRemainingShares.TabIndex = 5;
			this.labelRemainingShares.Text = "Remaining Shares:";
			// 
			// labelCostBasisSold
			// 
			this.labelCostBasisSold.AutoSize = true;
			this.labelCostBasisSold.Location = new System.Drawing.Point(12, 126);
			this.labelCostBasisSold.Name = "labelCostBasisSold";
			this.labelCostBasisSold.Size = new System.Drawing.Size(83, 13);
			this.labelCostBasisSold.TabIndex = 6;
			this.labelCostBasisSold.Text = "Cost Basis Sold:";
			// 
			// labelCostBasisRemaining
			// 
			this.labelCostBasisRemaining.AutoSize = true;
			this.labelCostBasisRemaining.Location = new System.Drawing.Point(12, 152);
			this.labelCostBasisRemaining.Name = "labelCostBasisRemaining";
			this.labelCostBasisRemaining.Size = new System.Drawing.Size(112, 13);
			this.labelCostBasisRemaining.TabIndex = 7;
			this.labelCostBasisRemaining.Text = "Cost Basis Remaining:";
			// 
			// labelTotalProfit
			// 
			this.labelTotalProfit.AutoSize = true;
			this.labelTotalProfit.Location = new System.Drawing.Point(12, 178);
			this.labelTotalProfit.Name = "labelTotalProfit";
			this.labelTotalProfit.Size = new System.Drawing.Size(61, 13);
			this.labelTotalProfit.TabIndex = 8;
			this.labelTotalProfit.Text = "Total Profit:";
			// 
			// labelNewShares
			// 
			this.labelNewShares.AutoSize = true;
			this.labelNewShares.Location = new System.Drawing.Point(12, 210);
			this.labelNewShares.Name = "labelNewShares";
			this.labelNewShares.Size = new System.Drawing.Size(68, 13);
			this.labelNewShares.TabIndex = 9;
			this.labelNewShares.Text = "New Shares:";
			// 
			// textBoxNewShares
			// 
			this.textBoxNewShares.Location = new System.Drawing.Point(104, 207);
			this.textBoxNewShares.Name = "textBoxNewShares";
			this.textBoxNewShares.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewShares.TabIndex = 10;
			// 
			// labelNewPrice
			// 
			this.labelNewPrice.AutoSize = true;
			this.labelNewPrice.Location = new System.Drawing.Point(12, 236);
			this.labelNewPrice.Name = "labelNewPrice";
			this.labelNewPrice.Size = new System.Drawing.Size(59, 13);
			this.labelNewPrice.TabIndex = 11;
			this.labelNewPrice.Text = "New Price:";
			// 
			// textBoxNewPrice
			// 
			this.textBoxNewPrice.Location = new System.Drawing.Point(104, 233);
			this.textBoxNewPrice.Name = "textBoxNewPrice";
			this.textBoxNewPrice.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewPrice.TabIndex = 12;
			// 
			// buttonAddLot
			// 
			this.buttonAddLot.Location = new System.Drawing.Point(15, 259);
			this.buttonAddLot.Name = "buttonAddLot";
			this.buttonAddLot.Size = new System.Drawing.Size(189, 23);
			this.buttonAddLot.TabIndex = 13;
			this.buttonAddLot.Text = "Add Lot";
			this.buttonAddLot.UseVisualStyleBackColor = true;
			this.buttonAddLot.Click += new System.EventHandler(this.buttonAddLot_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 300);
			this.Controls.Add(this.buttonAddLot);
			this.Controls.Add(this.textBoxNewPrice);
			this.Controls.Add(this.labelNewPrice);
			this.Controls.Add(this.textBoxNewShares);
			this.Controls.Add(this.labelNewShares);
			this.Controls.Add(this.labelTotalProfit);
			this.Controls.Add(this.labelCostBasisRemaining);
			this.Controls.Add(this.labelCostBasisSold);
			this.Controls.Add(this.labelRemainingShares);
			this.Controls.Add(this.buttonCalculate);
			this.Controls.Add(this.textBoxPricePerShare);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxSharesSold);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Cost Accounting";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}

