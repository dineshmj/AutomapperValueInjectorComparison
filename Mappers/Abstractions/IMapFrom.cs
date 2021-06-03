using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Mappers.Abstractions
{
	/// <summary>
	/// An abstraction to represent the mapping of data from one entity to another.
	/// </summary>
	/// <typeparam name="TFromEntity">The source entity instance, from which data is to be read.</typeparam>
	/// <typeparam name="TToEntity">The destination entity instance, on to which the read
	/// data is to be set.</typeparam>
	public interface IMapFrom<in TFromEntity, TToEntity>
	{
		/// <summary>
		/// Indicates if the specified mapper can map the incoming entity
		/// </summary>
		/// <param name="entity">The entity that decides if the mapper is capable
		/// of mapping or not.</param>
		/// <returns></returns>
		bool CanMap (TFromEntity entity);

		/// <summary>
		/// Maps data from a source entity instance, and returns a
		/// destination entity instance.
		/// </summary>
		/// <param name="sourceEntity">The source entity instance, from which
		/// data is to be read.</param>
		/// <returns>An instance of the destination entity containing the mapped
		/// data from the source entity.</returns>
		TToEntity MapDataFrom (TFromEntity sourceEntity);

		/// <summary>
		/// Maps data from a source entity instance, and returns a
		/// destination entity instance.
		/// </summary>
		/// <param name="sourceEntity">The source entity instance, from which
		/// data is to be read.</param>
		/// <param name="enrichThisInstance">The target entity instance to be enriched after mapping.</param>
		/// <returns>An instance of the destination entity containing the mapped
		/// data from the source entity.</returns>
		TToEntity MapDataFrom (TFromEntity sourceEntity, TToEntity enrichThisInstance);

		/// <summary>
		/// Maps data from a source list of entity instances, and returns a
		/// corresponding list of destination entity instances.
		/// </summary>
		/// <param name="sourceEntities">The list of source entity instances, from which
		/// data is to be read.</param>
		/// <returns>A list of instances of the destination entity containing the mapped
		/// data from the source list of entity instances.</returns>
		IEnumerable<TToEntity> MapDataFromList (IEnumerable<TFromEntity> sourceEntities);
	}
}