using AutoMapper;
using Fundo.Applications.Application.DTO;
using Fundo.Applications.Application.IRepository;
using Fundo.Applications.Application.UseCases.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Handlers.Queries
{
    public class GetLoanByIdRequestHandler : IRequestHandler<GetLoanByIdRequest, LoanDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;
        public GetLoanByIdRequestHandler(IMapper mapper, ILoanRepository loanRepository)
        {
          _mapper = mapper;
          _loanRepository = loanRepository;
        }
        public async Task<LoanDTO> Handle(GetLoanByIdRequest request, CancellationToken cancellationToken)
        {
            var getLoan = await _loanRepository.GetByIdAsync(request.Id);
            var getLoanDto = _mapper.Map<LoanDTO>(getLoan);
            return getLoanDto;
        }
    }
}
