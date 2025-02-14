using ControlBienes.Services.Models;

namespace ControlBienes.Services.Contracts
{
	public interface IEmailService
	{
		Task BSendEmailAsync(EmailModels email);
	}
}
