using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Payments.Application.Commands
{
    public record RefundPaymentCommand(Guid PaymentId) : IRequest;
}
