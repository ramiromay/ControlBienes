using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Sistema
{
	public interface IDatabaseHealthService
	{
		Task<bool> IsDatabaseConnectedAsync();
	}
}
