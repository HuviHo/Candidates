using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Candidates.Data
{
	public class CandidateRepository
	{
		private readonly string _connectionString;

		public CandidateRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public int AddCandidate(Candidate candidate)
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				context.Candidates.Add(candidate);
				context.SaveChanges();
			}
			return candidate.Id;
		}

		public List<Candidate> GetPending()
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				return context.Candidates.Where(c => c.Confirmed == null).ToList();
			}
		}
		
		public List<Candidate> GetConfirmed()
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				return context.Candidates.Where(c => c.Confirmed == true).ToList();
			}
		}

		public List<Candidate> GetDeclined()
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				return context.Candidates.Where(c => c.Confirmed == false).ToList();
			}
		}


		public Candidate GetCandidate(int id)
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				return context.Candidates.FirstOrDefault(c => c.Id == id);
			}
		}

		public void UpdateStatus(int id, bool confirmed)
		{
			using (var context = new CandidatesContext(_connectionString))
			{
				Candidate candidate = context.Candidates.FirstOrDefault(c => c.Id == id);
				candidate.Confirmed = confirmed;
				context.Candidates.Update(candidate);
				context.SaveChanges();
			}
		}
	}
}
