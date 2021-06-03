using System;

using Architecture.Experiments.AmViComp.Mappers.AutoMapper;

using AutoMapper;

namespace Architecture.Experiments.AmViComp.Mappers.Abstractions
{
	/// <summary>
	/// An abstraction to represent the mapping of data from one entity to another.
	/// </summary>
	/// <typeparam name="TFromEntity">The source entity instance, from which data is to be read.</typeparam>
	/// <typeparam name="TToEntity">The destination entity instance, on to which the read
	/// data is to be set.</typeparam>
	public abstract class AutoMapperBase<TFromEntity, TToEntity>
		: MapperBase<TFromEntity, TToEntity>
	{
		/// <summary>
		/// Maps data from a source entity instance, and returns a
		/// destination entity instance.
		/// </summary>
		/// <param name="sourceEntity">The source entity instance, from which
		/// data is to be read.</param>
		/// <param name="enrichThisInstance">The target entity instance to be enriched after mapping.</param>
		/// <returns>An instance of the destination entity containing the mapped
		/// data from the source entity.</returns>
		public override TToEntity MapDataFrom
			(
				TFromEntity sourceEntity,
				TToEntity enrichThisInstance
			)
		{
			// Is the target enirich instance of destination null?
			if (enrichThisInstance == null)
			{
				// Yes. Instantiate the destination instance.
				// NOTE: If the destination type is an interface, the below statement will fail.
				// NOTE: In such cases, the individual mappers must make their own implementation.
				enrichThisInstance = Activator.CreateInstance<TToEntity> ();
			}

			var config = new MapperConfiguration (cfg =>
			{
				cfg.AddProfile (AutoMapperProfile.DefinedInstance);
				cfg.CreateMap<TFromEntity, TToEntity> ();
			});

			var mapper = config.CreateMapper ();

			// mapper.Map(sourceEntity, enrichThisInstance);
			mapper.Map (sourceEntity, enrichThisInstance);
			return enrichThisInstance;
		}
	}
}