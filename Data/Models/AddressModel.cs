using System;

namespace Architecture.Experiments.AmViComp.Data.Models
{
	[Serializable]
	public sealed class AddressModel
	{
		public string FlatNumber { get; set; }
		public string BuildingNumber { get; set; }
		public string StreetName { get; set; }
		public string Locality { get; set; }
		public string City { get; set; }
		public string StateOrProvince { get; set; }
		public string Country { get; set; }
	}
}