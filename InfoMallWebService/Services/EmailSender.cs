using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoMallWebService.Services
{
	// This class is used by the application to send email for account confirmation and password reset.
	// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
	public class EmailSender : IEmailSender
	{
		private readonly ILogger<EmailSender> _logger;
		public EmailSender(ILogger<EmailSender> logger)
		{
			_logger = logger;
		}
		public async Task SendEmailAsync(string email, string subject, string message)
		{
			var mimeMessage = new MimeMessage();
			mimeMessage.From.Add(new MailboxAddress(
				"Nwisu Chisom",
				"nwisuchisom@gmail.com"
			));
			mimeMessage.To.Add(new MailboxAddress(
				"Victor Ilozulu",
				//"nwisuchisom@gmail.com"
				//"4165052480@pcs.rogers.com.
				//"08038714611@sms.co.ng."
				"victorilozulu@gmail.com"
				));
			//mimeMessage.Subject = "UCHE CAN YOU SEE THIS?";
			//mimeMessage.Subject = subject;
			mimeMessage.Subject = !string.IsNullOrEmpty(subject) ? subject : "MERRY CHRISTMAS";
			mimeMessage.Cc.Add(new MailboxAddress(email));
			mimeMessage.Body = !string.IsNullOrEmpty(message) ? new TextPart("plain") { Text = message } : new TextPart("plain")
			{
				//Text = "Dear Uche, \nCan you see this? If so, I sent it from my console application. \nRegards, \nNwisu."
				//Text = message
				//Text = "Dear Obinna, \nI call you 'Bi O' and Chika calls you 'Bina'."
				//Text = "Merry Christmas Ma, \nIf you can see this sms, I sent it from a C# application I built."
				Text = "Dear Victor, \nMerry Christmas and a prosperous new year."
			};

			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587, false);
				client.Authenticate("nwisuchisom@gmail.com", "Jesus&Mary4me");
				await client.SendAsync(mimeMessage);
				_logger.LogInformation("message sent successfully...");
				await client.DisconnectAsync(true);
			}

		}

		public async Task SendEmailToAllAsync(List<string> emails, string subject, string message)
		{
			var mimeMessage = new MimeMessage();
			mimeMessage.From.Add(new MailboxAddress(
				"Nwisu Chisom",
				"nwisuchisom@gmail.com"
			));
			
			foreach (string email in emails)
			{
				mimeMessage.Bcc.Add(new MailboxAddress(email));
			}
			
			//mimeMessage.Subject = "UCHE CAN YOU SEE THIS?";
			//mimeMessage.Subject = subject;
			mimeMessage.Subject = !string.IsNullOrEmpty(subject) ? subject : "MERRY CHRISTMAS";
			mimeMessage.Body = !string.IsNullOrEmpty(message) ? new TextPart("plain") { Text = message } : new TextPart("plain")
			{
				//Text = "Dear Uche, \nCan you see this? If so, I sent it from my console application. \nRegards, \nNwisu."
				//Text = message
				//Text = "Dear Obinna, \nI call you 'Bi O' and Chika calls you 'Bina'."
				//Text = "Merry Christmas Ma, \nIf you can see this sms, I sent it from a C# application I built."
				Text = "Dear Victor, \nMerry Christmas and a prosperous new year."
			};

			using (var client = new SmtpClient())
			{
				client.Connect("smtp.gmail.com", 587, false);
				client.Authenticate("nwisuchisom@gmail.com", "Jesus&Mary4me");
				await client.SendAsync(mimeMessage);
				_logger.LogInformation("message sent successfully...");
				await client.DisconnectAsync(true);
			}
		}
	}
}
