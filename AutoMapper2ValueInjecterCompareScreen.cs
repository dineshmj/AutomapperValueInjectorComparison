using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Architecture.Experiments.AmViComp.Data;
using Architecture.Experiments.AmViComp.Data.Entities;
using Architecture.Experiments.AmViComp.Data.Models;
using Architecture.Experiments.AmViComp.Mappers.AutoMapper;
using Architecture.Experiments.AmViComp.Serialization;

namespace Architecture.Experiments.AmViComp
{
	public partial class AutoMapper2ValueInjecterCompareScreen : Form
	{
		public AutoMapper2ValueInjecterCompareScreen ()
		{
			InitializeComponent ();
		}

		private void executeMappingButton_Click (object sender, EventArgs e)
		{
			// Models to entities.
			AutoMapperProfile.DefinedInstance.CreateMap<CustomerModel, Customer> ();
			AutoMapperProfile.DefinedInstance.CreateMap<CompanyModel, Company> ();
			AutoMapperProfile.DefinedInstance.CreateMap<AddressModel, Address> ();
			AutoMapperProfile.DefinedInstance.CreateMap<InstallmentModel, Installment> ();
			AutoMapperProfile.DefinedInstance.CreateMap<PolicyModel, Policy> ();

			// Entities to models.
			AutoMapperProfile.DefinedInstance.CreateMap<Customer, CustomerModel> ();
			AutoMapperProfile.DefinedInstance.CreateMap<Company, CompanyModel> ();
			AutoMapperProfile.DefinedInstance.CreateMap<Address, AddressModel> ();
			AutoMapperProfile.DefinedInstance.CreateMap<Installment, InstallmentModel> ();
			AutoMapperProfile.DefinedInstance.CreateMap<Policy, PolicyModel> ();

			var autoMapper = new AutoMapperBasedMapper ();
			var valueInjecterMapper = new ValueInjecterBasedMapper ();
			var serializer = new EntitySerializer ();

			// Get the data to map.
			var customerToMap = CustomerProvider.ProvideCustomer ();
			var company = new Company ();
			company.CompanyName = "MyCompany";
			company.Customers = new List<Customer> ();

			for (var i = 0; i < 100; i++)
			{
				company.Customers.Add (customerToMap);
			}

			// Prepare probe variales.
			DateTime startTime, endTime;
			TimeSpan durationTimeSpan;

			// Get the time taken for "AutoMapper"
			startTime = DateTime.Now;
			var mappedOutput = autoMapper.MapDataFrom (company);
			endTime = DateTime.Now;

			durationTimeSpan = endTime - startTime;

			// Set them to the UI fields for "AutoMapper".
			this.autoMapperTakesValueLabel.Text = durationTimeSpan.TotalMilliseconds + " ms";
			var text = this.autoMapperOutputTextBox.Text = serializer.Serialize (SerializationFormat.Json, mappedOutput);
			this.serializedOutputFromAutoMapperLabel.Text = @"Serialized AutoMapper Output. Hash = " + this.GetHashOfText (text);

			// Get the time taken for "AutoMapper"
			startTime = DateTime.Now;
			mappedOutput = valueInjecterMapper.MapDataFrom (company);
			endTime = DateTime.Now;

			durationTimeSpan = endTime - startTime;

			// Set them to the UI fields for "AutoMapper".
			this.valueInjecterTakesValueLabel.Text = durationTimeSpan.TotalMilliseconds + " ms";
			this.valueInjecterOutputTextBox.Text = serializer.Serialize (SerializationFormat.Json, mappedOutput);
			this.serializedOutputFromValueInjecterLabel.Text = @"Serialized Value Injecter Output. Hash = " + this.GetHashOfText (text);
		}

		/// <summary>
		/// Computes the hashed value of the text specified.
		/// </summary>
		/// <param name="textToHash">The text to be hashed.</param>
		/// <returns></returns>
		private string GetHashOfText (string textToHash)
		{
			using (var md5 = MD5.Create ())
			{
				var hashedText
					= BitConverter.ToString
						(
							md5.ComputeHash
								(
									Encoding.UTF8.GetBytes (textToHash)
								)
						)
						.Replace ("-", String.Empty);

				return (hashedText);
			}
		}
	}
}