using System;

namespace Architecture.Experiments.AmViComp.Data.Entities
{
	[Serializable]
	public sealed class Installment
	{
		public decimal InstallmentAmount { get; set; }
		public DateTime PaymentDate { get; set; }
	}
}