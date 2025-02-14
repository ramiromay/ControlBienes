using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Sistema.DatabaseHealth
{
	public class DatabaseHealthService : IDatabaseHealthService
	{
		private readonly AppDbContext _context;

		public DatabaseHealthService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> IsDatabaseConnectedAsync()
		{
			try
			{
				await _context.Database.ExecuteSqlRawAsync("SELECT 1");
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
