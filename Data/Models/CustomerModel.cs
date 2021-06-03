using System;
using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Data.Models
{
	[Serializable]
	public sealed class CustomerModel
	{
		public long ID { get; set; }
		public IList<byte> Picture { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public AddressModel PermanentAddress { get; set; }
		public AddressModel CommunicationAddress { get; set; }
		public IList<PolicyModel> Policies { get; set; }
	}
}