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
    public class GetAllLoanRequestHandler : IRequestHandler<GetAllLoanRequest, IReadOnlyList<LoanDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;
        public GetAllLoanRequestHandler(IMapper mapper, ILoanRepository loanRepository)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
        }

        public async Task<IReadOnlyList<LoanDTO>> Handle(GetAllLoanRequest request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsync();
            var loanDtos = _mapper.Map<List<LoanDTO>>(loans);
            return loanDtos;
        }
    }
}
