using ControlBienes.Services.Constants;

namespace ControlBienes.Services.Models
{
	public class EmailModels
	{
		public string? To { get; set; }

		public string? Subject { get; set; } = EmailTemplateConstants.WelcomeSubject;

		public string? Name { get; set; } = "Nuevo";

		public string? LastName { get; set; } = "Empleado";

		public string? NewPasssword { get; set; } = "xxxxxxxx";

		public EnumEmailTemplate? Template { get; set; } = EnumEmailTemplate.Welcome;
	}
}
