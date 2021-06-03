using System;
using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Data.Models
{
	[Serializable]
	public sealed class PolicyModel
	{
		public string PolicyId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal PremiumAmount { get; set; }
		public InstallmentModel [] Installments { get; set; }
	}
}