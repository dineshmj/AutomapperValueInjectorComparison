using System;

using Architecture.Experiments.AmViComp.Data.Entities;

namespace Architecture.Experiments.AmViComp.Data
{
	public static class CustomerProvider
	{
		public static Customer ProvideCustomer ()
		{
			Customer customer = new Customer
			{
				FirstName = "Dinesh",
				LastName = "Jayadevan",
				DateOfBirth = new DateTime (1973, 6, 1),
				ID = 1024,
				Picture = new [] { (byte) 65, (byte) 66, (byte) 67 },
				CommunicationAddress = new Address
				{
					FlatNumber = "C301",
					BuildingNumber = "820",
					Locality = "Lamplighter Park",
					StreetName = "153rd Ave NE",
					City = "Bellevue",
					StateOrProvince = "WA",
					Country = "USA"
				},
				PermanentAddress = new Address
				{
					FlatNumber = "C3",
					BuildingNumber = "20/4-1",
					Locality = "Sreeja Residency",
					StreetName = "26th Cross Road",
					City = "Bengaluru",
					StateOrProvince = "KA",
					Country = "India"
				},
				Policies = new []
				{
					new Policy
					{
						PolicyId = "2048ABC",
						StartDate = new DateTime (2018,1,1),
						EndDate = new DateTime (2018,3,30),
						PremiumAmount = 100,
						Installments = new []
						{
							new Installment
							{
								PaymentDate = new DateTime (2018,1,5),
								InstallmentAmount = 10
							},
							new Installment
							{
								PaymentDate = new DateTime (2018,1,15),
								InstallmentAmount = 10
							},new Installment
							{
								PaymentDate = new DateTime (2018,1,25),
								InstallmentAmount = 10
							}
						}
					},
					new Policy
					{
						PolicyId = "2048DEF",
						StartDate = new DateTime (2018,4,1),
						EndDate = new DateTime (2018,6,30),
						PremiumAmount = 200,
						Installments = new []
						{
							new Installment
							{
								PaymentDate = new DateTime (2018,4,5),
								InstallmentAmount = 20
							},
							new Installment
							{
								PaymentDate = new DateTime (2018,4,15),
								InstallmentAmount = 20
							},new Installment
							{
								PaymentDate = new DateTime (2018,4,25),
								InstallmentAmount = 20
							}
						}
					},
					new Policy
					{
						PolicyId = "2048GHI",
						StartDate = new DateTime (2018,5,1),
						EndDate = new DateTime (2018,9,30),
						PremiumAmount = 300,
						Installments = new []
						{
							new Installment
							{
								PaymentDate = new DateTime (2018,5,5),
								InstallmentAmount = 30
							},
							new Installment
							{
								PaymentDate = new DateTime (2018,5,15),
								InstallmentAmount = 30
							},new Installment
							{
								PaymentDate = new DateTime (2018,5,25),
								InstallmentAmount = 30
							}
						}
					}
				}
			};

			return (customer);
		}
	}
}