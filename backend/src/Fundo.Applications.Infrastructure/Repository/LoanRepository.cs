using Fundo.Applications.Application.IRepository;
using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Infrastructure.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext _dbContext;

        public LoanRepository(LoanDbContext loanDbContext)
        {
            _dbContext = loanDbContext;
        }
        public async Task<Loan> AddAsync(Loan loan)
        {
           await _dbContext.Loans.AddAsync(loan);
           await SaveChangesAsync();
            return loan;
        }

        public async Task<IReadOnlyList<Loan>> GetAllAsync()
        {
            return await _dbContext.Loans.AsNoTracking().ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(Guid loanId)
        {
            return await _dbContext.Loans.FirstOrDefaultAsync(x => x.Id == loanId);
        }

        public async Task SaveChangesAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _dbContext.Loans.Update(loan);
            await _dbContext.SaveChangesAsync();
        }
    }
}
