using EasySupport.Application.Commands.InsertTicket;
using EasySupport.Core.Emums;
using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using Moq;

namespace EasySupport.UnitTests.Application.Commands
{
    public class InsertTicketCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnTicketId()
        {
            // Arrange
            var ticketRepositoryMock = new Mock<ITicketRepository>();
            var notificationMock = new Mock<INotificationService>();

            var insertTicketCommand = new InsertTicketCommand
            {
                ClientId = 1,
                CategoryId = 1,
                SubcategoryId = 1,
                AttendantId = null,
                StatusTicketId = 1,
                OriginServiceId = 1,
                SolutionTicketId = null,
                Priority = Priority.Média,
                Description = "Teste de criação de ticket"
            };

            var insertTicketCommandHandler = new InsertTicketCommandHandler(ticketRepositoryMock.Object, notificationMock.Object);

            // Act
            var id = await insertTicketCommandHandler.Handle(insertTicketCommand, new CancellationToken());

            //Assert
            ticketRepositoryMock.Verify(t => t.AddAsync(It.IsAny<Ticket>()), Times.Once);
        }
    }
}
