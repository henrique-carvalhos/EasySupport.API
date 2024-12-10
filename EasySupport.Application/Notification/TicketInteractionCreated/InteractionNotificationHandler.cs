using MediatR;
using Microsoft.VisualBasic;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EasySupport.Application.Notification.TicketInteractionCreated
{
    public class InteractionNotificationHandler : INotificationHandler<TicketInteractionNotification>
    {
        private readonly ISendGridClient _sendGridClient;
        public InteractionNotificationHandler(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public async Task Handle(TicketInteractionNotification notification, CancellationToken cancellationToken)
        {
            var role = notification.Role == "Admin" ? "Atendente" : "Solicitante";

            var message = new SendGridMessage
            {
                From = new EmailAddress("xanol55376@ckuer.com", "EasySupport"),
                Subject = $"Ticket Nº: #{notification.TicketId} - {notification.Status}",
                HtmlContent = $@"
                    <strong>Ticket #{notification.TicketId} - Assunto: {notification.NameCategory} - {notification.NameSubcategory}</strong><br>
                    <hr>
                    <strong>Olá {notification.ClientName}, tudo bem?</strong><br><br>
                    <strong>Descrição:</strong> {notification.Description}<br><br>
                    <strong>Data criação:</strong> {notification.TicketCreatedAt}
                    <hr>
                    <strong>Interação:</strong> {notification.Message}<br>
                    <strong>Data interação:</strong> {notification.CreatedAt}<br>
                    <strong>{role}:</strong> {notification.AttendantName}"
            };

            message.AddTo(notification.ClientSendEmail, notification.ClientName);
            message.AddTo(notification.AttendantSendEmail, notification.AttendantName);
            message.AddCc(message.From);

            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
