using AutoMapper;
using Fundo.Applications.Application.DTO;
using Fundo.Applications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.Helper
{
    public class autoMapper: Profile
    {
        public autoMapper() {
            CreateMap<Loan, LoanDTO>();
        
        }

    }
}
