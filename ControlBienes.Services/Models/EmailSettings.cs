using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Services.Models
{
	public class EmailSettings
	{
		public string? FromAdress { get; set; }

		public string? FromName { get; set; }

		public string? FromPassword { get; set; }

		public string? SmtpServer { get; set; }

		public int SmtpPort { get; set; }

		public string? WelcomeHtmlFilePath { get; set; }

		public string? ForgotPasswordHtmlFilePath { get; set; }
	}
}
