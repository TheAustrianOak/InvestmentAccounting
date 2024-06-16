using BusinessLayer.Services;
using BusinessLayer.Services.Abstractions;
using DataLayer;
using Moq;

namespace BusinessLayer.Tests
{
	public class ShareServiceTests
	{
		private readonly Mock<IRepository> mockRepository;
		private readonly IShareService shareService;

        public ShareServiceTests()
        {
			mockRepository = new Mock<IRepository>();
			shareService = new ShareService(mockRepository.Object);
        }

		[Fact]
		public void GetTotalAvailableShares_ReturnsCorrectTotal()
		{
			// Arrange
			var lots = new List<Lot>
			{
				new Lot(100, 20),
				new Lot(150, 30),
				new Lot(120, 10)
			};
			mockRepository.Setup(repo => repo.GetLots()).Returns(lots);

			// Act
			int totalShares = shareService.GetTotalAvailableShares();

			// Assert
			Assert.Equal(370, totalShares);
		}

		[Fact]
		public void AddLot_AddsNewLotSuccessfully()
		{
			// Arrange
			var newLot = new Lot(100, 25);
			mockRepository.Setup(repo => repo.GetLots()).Returns(new List<Lot>());

			// Act
			shareService.AddLot(newLot.Shares, newLot.Price);

			// Assert
			mockRepository.Verify(repo => repo.AddLot(It.Is<Lot>(lot => lot.Shares == newLot.Shares && lot.Price == newLot.Price)), Times.Once);
		}

		[Fact]
		public void CalculateShares_ThrowsException_WhenSellingMoreSharesThanAvailable()
		{
			// Arrange
			var lots = new List<Lot>
			{
				new Lot(100, 20),
				new Lot(150, 30),
				new Lot(120, 10)
			};
			mockRepository.Setup(repo => repo.GetLots()).Returns(lots);

			// Act & Assert
			var exception = Assert.Throws<InvalidOperationException>(() => shareService.CalculateShares(400, 40));
			Assert.Equal("You cannot sell more shares than you have available. You have 370 shares available.", exception.Message);
		}

		[Fact]
		public void CalculateShares_ReturnsCorrectValues()
		{
			// Arrange
			var lots = new List<Lot>
			{
				new Lot(100, 20),
				new Lot(150, 30),
				new Lot(120, 10)
			};
			mockRepository.Setup(repo => repo.GetLots()).Returns(lots);

			// Act
			var result = shareService.CalculateShares(90, 20);

			// Assert
			Assert.Equal(220, result.RemainingShares);
			Assert.Equal(22.33m, Math.Round(result.CostBasisSold, 2));
			Assert.Equal(15.56m, Math.Round(result.CostBasisRemaining, 2));
			Assert.Equal(1000.00m, Math.Round(result.TotalProfit, 2));
		}
	}
}