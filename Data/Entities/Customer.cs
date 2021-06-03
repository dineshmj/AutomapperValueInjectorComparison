using System;

namespace Architecture.Experiments.AmViComp.Data.Entities
{
	[Serializable]
	public sealed class Customer
	{
		public long ID { get; set; }
		public byte [] Picture { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Address PermanentAddress { get; set; }
		public Address CommunicationAddress { get; set; }
		public Policy [] Policies { get; set; }
	}
}