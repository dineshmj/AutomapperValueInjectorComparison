using System;
using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Data.Entities
{
	[Serializable]
	public sealed class Company
	{
		public string CompanyName { get; set; }
		public IList<Customer> Customers { get; set; }
	}
}