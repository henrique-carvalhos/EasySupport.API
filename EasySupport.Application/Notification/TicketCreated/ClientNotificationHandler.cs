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
                HtmlContent = $@"
                    <strong>Olá {notification.NameClient}, tudo bem?</strong><br>
                    <hr>
                    <strong>Ticket #{notification.Id} - Assunto: {notification.NameCategory} - {notification.NameSubcategory}</strong><br>
                    <strong>Descrição:</strong> {notification.Description}<br>
                    <strong>Data criação:</strong> {notification.CreatedAt}"
            };

            message.AddTo(notification.SenderEmail, notification.NameClient);
            message.AddCc(message.From);

            await _sendGridClient.SendEmailAsync(message);

            //return Task.CompletedTask;
        }
    }
}
