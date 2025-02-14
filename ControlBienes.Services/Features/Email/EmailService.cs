using ControlBienes.Services.Constants;
using ControlBienes.Services.Contracts;
using ControlBienes.Services.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;
using System.Xml.Xsl;

namespace ControlBienes.Services.Features.Email
{
	public class EmailService : IEmailService
	{
		private readonly EmailSettings _emailSettings;
		private readonly ILogger<EmailService> _logger;
		
		public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
		{
			_emailSettings = emailSettings.Value;
			_logger = logger;
		}

		private async Task<BodyBuilder> BObtenerBody(EmailModels email)
		{
			var htmlBody = new StringBuilder(string.Empty);
			var textBody = new StringBuilder(string.Empty);

			if (email.Template == EnumEmailTemplate.Welcome)
			{
				var welcomeHtmlFilePath = _emailSettings.WelcomeHtmlFilePath;
				if (File.Exists(welcomeHtmlFilePath))
				{
					var nombreApellido = $"{email.Name} {email.LastName}";
					htmlBody.Append(await File.ReadAllTextAsync(welcomeHtmlFilePath));
					htmlBody.Replace(EmailTemplateConstants.WelcomeVarNombreApellido, nombreApellido);

					textBody.Append(EmailTemplateConstants.textBodyWelcome);
					textBody.Replace(EmailTemplateConstants.WelcomeVarNombreApellido, nombreApellido);
				}
			}
			else
			{
				var forgotPasswordHtmlFilePath = _emailSettings.ForgotPasswordHtmlFilePath;
				if (File.Exists(forgotPasswordHtmlFilePath))
				{

					htmlBody.Append(await File.ReadAllTextAsync(forgotPasswordHtmlFilePath));
					htmlBody.Replace(EmailTemplateConstants.ForgotPasswordVarNombre, email.Name);
					htmlBody.Replace(EmailTemplateConstants.ForgotPasswordVarContrasenia, email.NewPasssword);

					textBody.Append(EmailTemplateConstants.textBodyForgotPassword);
					textBody.Replace(EmailTemplateConstants.ForgotPasswordVarNombre, email.Name);
					textBody.Replace(EmailTemplateConstants.ForgotPasswordVarContrasenia, email.NewPasssword);
				}
			}
			var body = new BodyBuilder
			{
				TextBody = textBody.ToString(),
				HtmlBody = htmlBody.ToString()
			};
			return body;
		}

		public async Task BSendEmailAsync(EmailModels email)
		{
			var nombreMetodo = nameof(BSendEmailAsync);
			_logger.LogInformation($"{128937183787123}: Inicia la operacion para enviar un correo");

			try
			{
				var nameAndLastName = $"{email.Name} {email.LastName}";
				var body = await BObtenerBody(email);
				var from = new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAdress);
				var to = new MailboxAddress(nameAndLastName.Trim(), email.To);

				var message = new MimeMessage();
				message.From.Add(from);
				message.To.Add(to);
				message.Subject = email.Subject;
				message.Body = body.ToMessageBody();

				using (var client = new SmtpClient())
				{
					client.CheckCertificateRevocation = false;
					await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
					await client.AuthenticateAsync(_emailSettings.FromAdress, _emailSettings.FromPassword);
					await client.SendAsync(message);
					await client.DisconnectAsync(true);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"{-128937183787123} {nombreMetodo}: Ocurrio un error al mandar el correo ({ex.Message})");
			}
		}
	}
}
