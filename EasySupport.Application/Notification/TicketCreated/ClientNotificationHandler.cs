using MediatR;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EasySupport.Application.Notification.TicketCreated
{
    public class ClientNotificationHandler : INotificationHandler<TicketCreatedNotification>
    {
        private readonly ISendGridClient _sendGridClient;
        public ClientNotificationHandler(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task Handle(TicketCreatedNotification notification, CancellationToken cancellationToken)
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress("xanol55376@ckuer.com", "EasySupport"),
                Subject = $"Aberto: Ticket Nº: #{notification.Id}",
                PlainTextContent = $"Ticket #{notification.Id} - Assunto: {notification.NameCategory} - {notification.NameSubcategory} \n" +
                $"Status: {notification.NameStatusTicket}\n" +
                $"Descrição: {notification.Description}\n" +
                $"Prioridade: {notification.Priority}\n" +
                $"Data criação: {notification.CreatedAt}"
            };

            message.AddTo(notification.SenderEmail, notification.NameClient);
            message.AddCc(message.From);

            await _sendGridClient.SendEmailAsync(message);

            //return Task.CompletedTask;
        }
    }
}
