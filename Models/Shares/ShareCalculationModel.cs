using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Shares
{
	public class ShareCalculationModel
	{
        public int RemainingShares { get; set; }
        public decimal CostBasisSold { get; set; }
        public decimal CostBasisRemaining { get; set; }
        public decimal TotalProfit { get; set; }
    }
}
