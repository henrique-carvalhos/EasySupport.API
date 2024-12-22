using EasySupport.Application.Queries.GetAllTicket;
using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using Moq;

namespace EasySupport.UnitTests.Application.Queries
{
    public class GetAllTicketsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeTicketaExists_Executed_ReturnThreeTickesViewModel()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new(1,1, 1,1,1,1,1, 0, "Teste unitário do retorno do TicketViewModel"),
                new(2,1,1,1,1,1,1,0, "Teste unitário do retorno do TicketViewModel com todos os dados"),
                new(2,null,1,1,1,1,null,0, "Teste unitário do retorno do TicketViewModel com todos os dados")
            };

            var ticketRepositoryMock = new Mock<ITicketRepository>();

            ticketRepositoryMock.Setup(t => t.GetAllAsync("").Result).Returns(tickets);

            var getAllTicketQuery = new GetAllTicketQuery("");
            var getAllTicketQueryHandler = new GetAllTicketQueryHandler(ticketRepositoryMock.Object);

            // Act
            var ticketViewModelList = await getAllTicketQueryHandler.Handle(getAllTicketQuery, new CancellationToken());

            //Assert
            Assert.NotNull(ticketViewModelList);

            ticketRepositoryMock.Verify(t => t.GetAllAsync("").Result, Times.Once);
        }
    }
}
