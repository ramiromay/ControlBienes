namespace ControlBienes.Services.Constants
{
	public class EmailTemplateConstants
	{
		public const string ForgotPasswordSubject = "Recuperar contraseña para SICBA";

		public const string WelcomeSubject = "Bienvenido a SICBA";

		public const string ForgotPasswordVarNombre = "{{nombre}}";

		public const string ForgotPasswordVarContrasenia = "{{contrasenia}}";

		public const string WelcomeVarNombreApellido = "{{nombreApellido}}";

		public const string textBodyWelcome = "Hola, {{nombreApellido}}:\nTe damos la bienvenida a SICBA. Nos complace informarte que ahora puedes acceder a los diferentes sistemas de administración de bienes, diseñados para facilitar la gestión y optimizar tus procesos.\nEstamos seguros de que juntos lograremos grandes cosas.";

		public const string textBodyForgotPassword = "Hola, {{nombre}}:\nHemos recibido una solicitud para restablecer la contraseña asociada a tu cuenta en el Sistema Integral de Control de Bienes y Almacenes. Tu nueva contraseña es:\n{{contrasenia}}\nNo reenvíes este correo electrónico ni des tu contraseña a nadie. Has recibido este mensaje porque esta dirección de correo electrónico figura como dirección principal de su cuenta en SICBA.\nAtentamente,\nEl equipo de SICBA\nEste es un mensaje automático, por favor no responda.";
	}
}
