using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Candidates.Data;

namespace Candidates.Data
{
	public class NavbarAttribute : ActionFilterAttribute
	{

		private string _connectionString;

		public NavbarAttribute(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConStr");
		}
		
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			var controller = (Controller)context.Controller;
			CandidateRepository repository = new CandidateRepository(_connectionString);
			controller.ViewBag.Pending = repository.GetPending().Count();
			controller.ViewBag.Confirmed = repository.GetConfirmed().Count();
			controller.ViewBag.Declined = repository.GetDeclined().Count();
			base.OnActionExecuted(context);
		}
	}
}
