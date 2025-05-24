using AutoMapper;
using Fundo.Applications.Application.IRepository;
using Fundo.Applications.Application.Responses;
using Fundo.Applications.Application.UseCases.Requests.Commands;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Handlers.Commands
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _loanRepository;
        private readonly ILogger<CreateLoanCommandHandler> _logger;
        public CreateLoanCommandHandler(IMapper mapper, ILoanRepository loanRepository, ILogger<CreateLoanCommandHandler> logger)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
            _logger = logger;
        }
        public async Task<BaseCommandResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var response = new BaseCommandResponse();
                var newLoan = new Loan
                {
                    Id = Guid.NewGuid(),
                    Amount = request.LoanDto.Amount,
                    ApplicantName = request.LoanDto.ApplicantName,
                    ApplicantId = Guid.NewGuid().ToString(),
                    CurrentBalance = request.LoanDto.Amount,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = Domain.Enums.LoanStatus.Active
                };
                var loadSent = await _loanRepository.AddAsync(newLoan);
                if (loadSent != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Loan was created sucessful";
                    response.Id = loadSent.Id;
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating loan for {Applicant}", request.LoanDto.ApplicantName);
                throw;
            }
        }
    }
    }

