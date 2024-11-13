using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface IPaymentService
{
    bool ProcessPayment(PaymentInfo paymentInfo);
}
