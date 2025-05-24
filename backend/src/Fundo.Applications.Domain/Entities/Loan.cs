using Fundo.Applications.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Domain.Entities
{
    public class Loan: BaseEntity
    {
        public decimal Amount { get;  set; }
        public decimal CurrentBalance { get; set; }
        public string ApplicantName { get;  set; }
        public string ApplicantId { get;  set; }
        public LoanStatus Status { get;  set; }

    }
}
