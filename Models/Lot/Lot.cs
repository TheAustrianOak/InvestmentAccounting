namespace DataLayer
{
	public class Lot
	{
		public int Shares { get; set; }
		public decimal Price { get; }

		public Lot(int shares, decimal price)
		{
			Shares = shares;
			Price = price;
		}
	}
}
