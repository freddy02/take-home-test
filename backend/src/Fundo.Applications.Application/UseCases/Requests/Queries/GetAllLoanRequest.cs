using Fundo.Applications.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.UseCases.Requests.Queries
{
    public class GetAllLoanRequest: IRequest<IReadOnlyList<LoanDTO>>
    {
    }
}
