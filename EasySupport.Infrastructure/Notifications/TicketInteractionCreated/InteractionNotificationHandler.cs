﻿using MediatR;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace EasySupport.Infrastructure.Notifications.TicketInteractionCreated
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
            var interactions = "";

            foreach (var interation in notification.Interactions)
            {
                var role = interation.Role == "Admin" ? "Atendente" : "Solicitante";
                var resolvido = interation.StatusTicket.Contains("Resolvido") ? $"<strong>Ação:</strong> {interation.SolutionTicket}<br>" : "";

                interactions += $@"
                    <strong>Interação:</strong> {interation.Message}<br>
                    <strong>Data interação:</strong> {interation.CreatedAt}<br>
                    <strong>{role}:</strong> {interation.AttendantName}<br>
                    {resolvido}
                    <hr>";
            }

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
                    {interactions}"
            };

            message.AddTo(notification.ClientSendEmail, notification.ClientName);
            message.AddTo(notification.AttendantSendEmail, notification.AttendantName);
            message.AddCc(message.From);

            await _sendGridClient.SendEmailAsync(message);
        }
    }
}
