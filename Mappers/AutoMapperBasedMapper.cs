using Architecture.Experiments.AmViComp.Data.Entities;
using Architecture.Experiments.AmViComp.Data.Models;
using Architecture.Experiments.AmViComp.Mappers.Abstractions;

namespace Architecture.Experiments.AmViComp
{
	/// <summary>
	/// A mappper class based on "AutoMapper" library based mapping.
	/// </summary>
	public sealed class AutoMapperBasedMapper
		: AutoMapperBase<Company, CompanyModel>
	{
		// Intentionally left blank.
	}
}