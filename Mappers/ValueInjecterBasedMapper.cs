using Architecture.Experiments.AmViComp.Data.Entities;
using Architecture.Experiments.AmViComp.Data.Models;
using Architecture.Experiments.AmViComp.Mappers.Abstractions;

namespace Architecture.Experiments.AmViComp
{
	/// <summary>
	/// A mappper class based on "ValueInjecter" library based mapping.
	/// </summary>
	public sealed class ValueInjecterBasedMapper
		: ValueInjecterMapperBase<Company, CompanyModel>
	{
		// Intentionally left blank.
	}
}