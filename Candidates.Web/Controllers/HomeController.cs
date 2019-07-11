using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Candidates.Web.Models;
using Candidates.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Candidates.Web.Controllers
{
	public class HomeController : Controller
	{

		private IHostingEnvironment _environment;
		private string _connectionString;

		public HomeController(IHostingEnvironment environment, IConfiguration configuration)
		{
			_environment = environment;
			_connectionString = configuration.GetConnectionString("ConStr");
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddCandidate()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCandidate(Candidate candidate)
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			int id = repository.AddCandidate(candidate);
			return Redirect($"/home/viewCandidate?id={id}");
		}

		public IActionResult ViewPending()
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			return View(repository.GetPending());
		}

		public IActionResult ViewConfirmed()
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			return View(repository.GetConfirmed());
		}

		public IActionResult ViewDeclined()
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			return View(repository.GetDeclined());
		}

		public IActionResult ViewCandidate(int id)
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			return View(repository.GetCandidate(id));
		}
		
		[HttpPost]
		public JsonResult UpdateStatus(int id, bool confirmed)
		{
			CandidateRepository repository = new CandidateRepository(_connectionString);
			repository.UpdateStatus(id, confirmed);
			ViewBag.Pending = repository.GetPending().Count();
			ViewBag.Confirmed = repository.GetConfirmed().Count();
			ViewBag.Declined = repository.GetDeclined().Count();
			return Json(ViewBag);
		}
	}
}
