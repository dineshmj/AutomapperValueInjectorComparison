using System.Collections.Generic;

namespace Architecture.Experiments.AmViComp.Serialization
{
	/// <summary>
	/// Represents the various serialization formats.
	/// </summary>
	public interface ISerializer
	{
		/// <summary>
		/// The serialization formats supported by this serializer.
		/// </summary>
		IEnumerable<SerializationFormat> SupportedFormats { get; }

		/// <summary>
		/// Serializes the entity to the specified format.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="serializationFormat">The serialization format to be used.</param>
		/// <param name="entity">The generic entity to be formatted.</param>
		/// <returns></returns>
		string Serialize<TEntity>
			(
				SerializationFormat serializationFormat,
				TEntity entity
			);

		/// <summary>
		/// De-serializes the contents into an entity instance using the specified format.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="serializationFormat">The serialization format to be used.</param>
		/// <param name="serializedContent">The content that has to be de-serialized into an entity instance..</param>
		/// <returns>An instance of the generic type obtained by de-seralizing the content specified.</returns>
		TEntity DeSerialize<TEntity>
			(
				SerializationFormat serializationFormat,
				string serializedContent
			);

		/// <summary>
		/// Clones the entity.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="entity">The generic entity to be formatted.</param>
		/// <returns></returns>
		TEntity Clone<TEntity>
			(
				TEntity entity
			);
	}
}