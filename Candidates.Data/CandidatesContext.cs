﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candidates.Data
{
	public class CandidatesContext : DbContext
	{
		private string _connectionString;

		public CandidatesContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public DbSet<Candidate> Candidates { get; set; }

		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}
