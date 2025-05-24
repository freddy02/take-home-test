using Fundo.Applications.Application.DTO;
using Fundo.Applications.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Requests.Commands
{
    public class CreateLoanCommand: IRequest<BaseCommandResponse>
    {
        public LoanDTO LoanDto { get; set; }
    }
}
