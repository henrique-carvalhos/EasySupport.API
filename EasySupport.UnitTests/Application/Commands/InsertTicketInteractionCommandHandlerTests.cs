using EasySupport.Application.Commands.InsertTicketInteraction;
using EasySupport.Core.Entities;
using EasySupport.Core.Repositories;
using EasySupport.Core.Services;
using Moq;

namespace EasySupport.UnitTests.Application.Commands
{
    public class InsertTicketInteractionCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnTicketId()
        {
            // Arrange
            var ticketInteractionRepositoryMock = new Mock<ITicketInteractionRepository>();
            var ticketRepositoryMock = new Mock<ITicketRepository>();
            var notificationMock = new Mock<INotificationService>();

            var insertTicketInteractionCommand = new InsertTicketInteractionCommand
            {
                TicketId = 35,
                AttendantId = 6,
                StatusTicketId = 1,
                SolutionTicketId = 1,
                Message = "teste unítário de interação do ticket",
                CreatedAt = DateTime.Now
            };

            var insertTicketInteractionCommandHandler = new InsertTicketInteractionCommandHandler(ticketInteractionRepositoryMock.Object, ticketRepositoryMock.Object, notificationMock.Object);

            // Act
            var id = await insertTicketInteractionCommandHandler.Handle(insertTicketInteractionCommand, new CancellationToken());

            //Assert
            ticketInteractionRepositoryMock.Verify(i => i.AddAsync(It.IsAny<TicketInteraction>()), Times.Once());
        }
    }
}
