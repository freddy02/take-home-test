using AutoMapper;
using Fundo.Applications.Application.IRepository;
using Fundo.Applications.Application.UseCases.Requests.Commands;
using Fundo.Applications.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Handlers.Commands
{
    public class MakeLoanPaymentCommandHandler : IRequestHandler<MakeLoanPaymentCommand, bool>
    {
        private readonly ILoanRepository _loanRepository;
        public MakeLoanPaymentCommandHandler(IMapper mapper, ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<bool> Handle(MakeLoanPaymentCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.LoanId);
            if (loan == null || loan.Status != LoanStatus.Active)
                return false;

            if (loan.CurrentBalance < request.PaidAmount)
                throw new InvalidOperationException("Insufficient balance.");

            loan.CurrentBalance -= request.PaidAmount;
            loan.UpdatedAt = DateTime.UtcNow;

            await _loanRepository.UpdateAsync(loan);
            return true;
        }
    }
}
