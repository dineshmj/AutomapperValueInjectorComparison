using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Experiments.AmViComp.Mappers.Abstractions
{
	/// <summary>
	/// An abstraction to represent the mapping of data from one entity to another.
	/// </summary>
	/// <typeparam name="TFromEntity">The source entity instance, from which data is to be read.</typeparam>
	/// <typeparam name="TToEntity">The destination entity instance, on to which the read
	/// data is to be set.</typeparam>
	public abstract class MapperBase<TFromEntity, TToEntity>
		: IMapFrom<TFromEntity, TToEntity>
	{
		#region Methods.

		/// <summary>
		/// Indicates if the specified mapper can map the incoming entity
		/// </summary>
		/// <param name="entity">The entity that decides if the mapper is capable
		/// of mapping or not.</param>
		/// <returns></returns>
		public virtual bool CanMap
		(
			TFromEntity entity)
		{
			return (entity != null);
		}

		/// <summary>
		/// Maps data from a source entity instance, and returns a
		/// destination entity instance.
		/// </summary>
		/// <param name="sourceEntity">The source entity instance, from which
		/// data is to be read.</param>
		/// <returns>An instance of the destination entity containing the mapped
		/// data from the source entity.</returns>
		public virtual TToEntity MapDataFrom (TFromEntity sourceEntity)
		{
			// Instantiate the destination instance.
			// NOTE: If the destination type is an interface, the below statement will fail.
			// NOTE: In such cases, the individual mappers must make their own implementation.
			var destination = Activator.CreateInstance<TToEntity> ();

			return
				(
					this.MapDataFrom
						(
							sourceEntity,
							destination
						)
				);
		}

		/// <summary>
		/// Maps data from a source entity instance, and returns a
		/// destination entity instance.
		/// </summary>
		/// <param name="sourceEntity">The source entity instance, from which
		/// data is to be read.</param>
		/// <param name="enrichThisInstance">The target entity instance to be enriched after mapping.</param>
		/// <returns>An instance of the destination entity containing the mapped
		/// data from the source entity.</returns>
		public virtual TToEntity MapDataFrom
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

			// Get the source and destination properties.
			var sourceProperties = typeof (TFromEntity).GetProperties ().ToList ();
			var destinProperties = typeof (TToEntity).GetProperties ().ToList ();

			var targetInstance = enrichThisInstance;

			// Walk through each source property, and identify the correspondig destination property.
			sourceProperties
				.ForEach
				(
					sp =>
					{
						// Get the corresponding property of the destination type.
						var targetProperty = destinProperties.FirstOrDefault (p => p.Name == sp.Name);

						// Is there a matching destination type, and can it be set with a value?
						if (targetProperty != null && targetProperty.CanWrite)
						{
							// Yes. Attempt to set the destination property value, by reading that from the source property.
							try
							{
								targetProperty.SetValue (targetInstance, sp.GetValue (sourceEntity));
							}
							catch (Exception ex)
							{
								// Assignment did not succeed. Here is the exception message.
								var exMessage = ex.Message;
							}
						}
					}
				);

			// Destination instance is prepared. Send it back.
			return (enrichThisInstance);
		}

		/// <summary>
		/// Maps data from a source list of entity instances, and returns a
		/// corresponding list of destination entity instances.
		/// </summary>
		/// <param name="sourceEntities">The list of source entity instances, from which
		/// data is to be read.</param>
		/// <returns>A list of instances of the destination entity containing the mapped
		/// data from the source list of entity instances.</returns>
		public virtual IEnumerable<TToEntity> MapDataFromList (IEnumerable<TFromEntity> sourceEntities)
		{
			return
				(
					sourceEntities
						.Where (this.CanMap)
						.Select (this.MapDataFrom)
						.ToArray ()
				);
		}

		#endregion
	}
}