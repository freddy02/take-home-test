using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Requests.Commands
{
    public class MakeLoanPaymentCommand: IRequest<bool>
    {
        public Guid LoanId { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
