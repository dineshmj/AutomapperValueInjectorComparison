using System;
using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Data.Models
{
	[Serializable]
	public sealed class CompanyModel
	{
		public string CompanyName { get; set; }
		public IList<CustomerModel> Customers { get; set; }
	}
}