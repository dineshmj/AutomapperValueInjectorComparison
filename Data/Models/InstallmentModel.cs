using System;

namespace Architecture.Experiments.AmViComp.Data.Models
{
	[Serializable]
	public sealed class InstallmentModel
	{
		public decimal InstallmentAmount { get; set; }
		public DateTime PaymentDate { get; set; }
	}
}