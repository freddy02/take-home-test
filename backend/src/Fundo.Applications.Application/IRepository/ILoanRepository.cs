using Fundo.Applications.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.IRepository
{
    public interface ILoanRepository
    {
        Task<Loan> AddAsync(Loan loan);
        Task<Loan> GetByIdAsync(Guid loan);
        Task<IReadOnlyList<Loan>> GetAllAsync();
        Task UpdateAsync(Loan loan);
        Task SaveChangesAsync();
    }
}
