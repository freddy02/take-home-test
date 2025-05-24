using Fundo.Applications.Domain.Entities;
using Fundo.Applications.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Infrastructure.Data
{
    public static class LoanDbContextSeeder
    {
        public static async Task SeedAsync(LoanDbContext context)
        {
            if (!context.Loans.Any())
            {
                context.Loans.AddRange(
                      new Loan
                      {
                          Id = Guid.NewGuid(),
                          Amount = 1000,
                          CurrentBalance = 1000,
                          ApplicantName = "Alice Johnson",
                          ApplicantId = "A1001",
                          Status = LoanStatus.Pending,
                          CreatedAt = DateTime.UtcNow,
                          UpdatedAt = DateTime.UtcNow
                      },
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        Amount = 2500,
                        CurrentBalance = 2000,
                        ApplicantName = "Bob Smith",
                        ApplicantId = "B2002",
                        Status = LoanStatus.Active,
                        CreatedAt = DateTime.UtcNow.AddDays(-10),
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        Amount = 5000,
                        CurrentBalance = 4500,
                        ApplicantName = "Carol White",
                        ApplicantId = "C3003",
                        Status = LoanStatus.Active,
                        CreatedAt = DateTime.UtcNow.AddDays(-30),
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        Amount = 1500,
                        CurrentBalance = 1500,
                        ApplicantName = "David Brown",
                        ApplicantId = "D4004",
                        Status = LoanStatus.Pending,
                        CreatedAt = DateTime.UtcNow.AddDays(-5),
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        Amount = 3000,
                        CurrentBalance = 2800,
                        ApplicantName = "Eva Green",
                        ApplicantId = "E5005",
                        Status = LoanStatus.Active,
                        CreatedAt = DateTime.UtcNow.AddDays(-20),
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Loan
                    {
                        Id = Guid.NewGuid(),
                        Amount = 4000,
                        CurrentBalance = 3500,
                        ApplicantName = "Frank Black",
                        ApplicantId = "F6006",
                        Status = LoanStatus.Pending,
                        CreatedAt = DateTime.UtcNow.AddDays(-60),
                        UpdatedAt = DateTime.UtcNow
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
