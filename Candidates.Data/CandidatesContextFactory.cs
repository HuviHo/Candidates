using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Candidates.Data
{
	public class CandidatesContextFactory : IDesignTimeDbContextFactory<CandidatesContext>
	{
		public CandidatesContext CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Candidates.Web"))
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

			return new CandidatesContext(config.GetConnectionString("ConStr"));
		}
	}
}
