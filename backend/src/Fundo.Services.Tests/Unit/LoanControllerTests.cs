using Fundo.Applications.Application.DTO;
using Fundo.Applications.Application.Responses;
using Fundo.Applications.Application.UseCases.Requests.Commands;
using Fundo.Applications.Application.UseCases.Requests.Queries;
using Fundo.Applications.Domain.Enums;
using Fundo.Applications.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fundo.Services.Tests.Unit
{
    public class LoanControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly LoanManagementController _controller;
        private readonly Mock<ILogger<LoanManagementController>> _loggerMock;

        public LoanControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<LoanManagementController>>();
            _controller = new LoanManagementController(_mediatorMock.Object, _loggerMock.Object);

        }

        [Fact]
        public async Task GetAllLoans_ReturnsOk()
        {
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllLoanRequest>(), default))
                         .ReturnsAsync(new List<LoanDTO>());

            var result = await _controller.GetAllLoans();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<LoanDTO>>(okResult.Value);
        }

        [Fact]
        public async Task CreateLoan_ReturnsLoanId()
        {
            var loanDto = new LoanDTO { Amount = 1000, ApplicantName = "Alice", CurrentBalance = 1000, Status = LoanStatus.Active };
            var response = new BaseCommandResponse { Id = Guid.NewGuid(), IsSuccess = true, Message = "Loan created successfully" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateLoanCommand>(), default))
                         .ReturnsAsync(response);

            var result = await _controller.CreateLoan(loanDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Guid>(okResult.Value);
            Assert.Equal(response.Id, okResult.Value);
        }

        [Fact]
        public async Task MakePayment_ReturnsOk_WhenSuccessful()
        {
            var loanId = Guid.NewGuid();
            _mediatorMock.Setup(m => m.Send(It.IsAny<MakeLoanPaymentCommand>(), default))
                         .ReturnsAsync(true);

            var result = await _controller.MakePayment(loanId, new PaymentDTO { PaidAmount = 100 });

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Payment applied.", okResult.Value);
        }

        [Fact]
        public async Task GetLoanById_ReturnsLoan_WhenExists()
        {
            var loanId = Guid.NewGuid();
            var expectedLoan = new LoanDTO
            {
                Id = loanId,
                Amount = 500,
                ApplicantName = "Jane Smith"
            };

            _mediatorMock.Setup(m => m.Send(It.Is<GetLoanByIdRequest>(q => q.Id == loanId), default))
                         .ReturnsAsync(expectedLoan);

            var result = await _controller.GetLoanById(loanId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualLoan = Assert.IsType<LoanDTO>(okResult.Value);
            Assert.Equal(loanId, actualLoan.Id);
        }
    }
}
