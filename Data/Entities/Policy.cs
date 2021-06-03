using System;
using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Data.Entities
{
	[Serializable]
	public sealed class Policy
	{
		public string PolicyId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal PremiumAmount { get; set; }
		public IList<Installment> Installments { get; set; }
	}
}