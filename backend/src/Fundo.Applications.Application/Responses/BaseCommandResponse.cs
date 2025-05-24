using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundo.Applications.Application.Responses
{
    public class BaseCommandResponse
    {
        public Guid Id { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

    }
}
