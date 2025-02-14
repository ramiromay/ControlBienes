using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Exceptions
{
	public class BusConflictoException : Exception
	{
		public BusConflictoException(string message) : base(message)
		{
		}
	}
}
