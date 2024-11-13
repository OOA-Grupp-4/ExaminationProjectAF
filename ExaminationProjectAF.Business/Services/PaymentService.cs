using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Services;

public class PaymentService : IPaymentService
{
    private readonly ICartService _cartService;

    public PaymentService(ICartService cartService)
    {
        _cartService = cartService;
    }

    public bool ProcessPayment(PaymentInfo paymentInfo)
    {
        if (string.IsNullOrEmpty(paymentInfo.CardNumber) || string.IsNullOrEmpty(paymentInfo.CardHolderName))
        {
            throw new ArgumentException("Invalid payment information");
        }
        else
        {
            _cartService.ClearCart();
            return true;
        }
    }
}
