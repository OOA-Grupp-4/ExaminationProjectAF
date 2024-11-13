using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;
using ExaminationProjectAF.Business.Services;
using Moq;

namespace ExaminationProjectAF.Tests;

public class PaymentService_Tests
{
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly PaymentService _paymentService;

    public PaymentService_Tests()
    {
        _cartServiceMock = new Mock<ICartService>();
        _paymentService = new PaymentService(_cartServiceMock.Object);
    }

    [Fact]
    public void ProcessPayment_ShouldClearCart_OnSuccessfulPayment()
    {
        // Arrange
        var paymentInfo = new PaymentInfo
        {
            CardNumber = "1234-5678-9012-3456",
            CardHolderName = "John Smith"
        };

        bool isCartCleared = false;
        _cartServiceMock.Setup(x => x.ClearCart()).Callback(() => isCartCleared = true);

        // Act
        var result = _paymentService.ProcessPayment(paymentInfo);

        // Assert
        Assert.True(result);
        Assert.True(isCartCleared);
    }
}
