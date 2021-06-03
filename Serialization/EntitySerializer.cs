using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Newtonsoft.Json;

namespace Architecture.Experiments.AmViComp.Serialization
{
	/// <summary>
	/// Represents the various serialization formats.
	/// </summary>
	public sealed partial class EntitySerializer
		: ISerializer
	{
		/// <summary>
		/// The serialization formats supported by this serializer.
		/// </summary>
		public IEnumerable<SerializationFormat> SupportedFormats
		{
			get
			{
				return
					(
						new ReadOnlyCollection<SerializationFormat>
							(
								new []
								{
									SerializationFormat.Json,
									SerializationFormat.PrettyString
								}
							)
					);
			}
		}

		/// <summary>
		/// Serializes the entity to the specified format.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="serializationFormat">The serialization format to be used.</param>
		/// <param name="entity">The generic entity to be formatted.</param>
		/// <returns></returns>
		public string Serialize<TEntity>
			(
				SerializationFormat serializationFormat,
				TEntity entity
			)
		{
			switch (serializationFormat)
			{
				// JSON.
				case SerializationFormat.Json:
					return (JsonConvert.SerializeObject (entity));

				// Unknown serialization format.
				case SerializationFormat.Unknown:
					throw (new InvalidOperationException ("Cannot work with 'Unknown' format."));

				// Unsupported serialization format.
				default:
					throw (new NotImplementedException ("The specified format '" + serializationFormat + "' is not supported for serialization."));
			}
		}

		/// <summary>
		/// De-serializes the contents into an entity instance using the specified format.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="serializationFormat">The serialization format to be used.</param>
		/// <param name="serializedContent">The content that has to be de-serialized into an entity instance..</param>
		/// <returns>An instance of the generic type obtained by de-seralizing the content specified.</returns>
		public TEntity DeSerialize<TEntity>
			(
				SerializationFormat serializationFormat,
				string serializedContent
			)
		{
			switch (serializationFormat)
			{
				// JSON.
				case SerializationFormat.Json:
					return (JsonConvert.DeserializeObject<TEntity> (serializedContent));

				// Unknown serialization format.
				case SerializationFormat.Unknown:
					throw (new InvalidOperationException ("Cannot work with 'Unknown' format."));

				// Unsupported deserialization format.
				default:
					throw (new NotImplementedException ("The specified format '" + serializationFormat + "' is not supported for de-serialization."));
			}
		}


		/// <summary>
		/// Clones the entity.
		/// </summary>
		/// <typeparam name="TEntity">The generic entity type.</typeparam>
		/// <param name="entity">The generic entity to be formatted.</param>
		/// <returns></returns>
		public TEntity Clone<TEntity> (TEntity entity)
		{
			return this.DeSerialize<TEntity> (SerializationFormat.Json, this.Serialize<TEntity> (SerializationFormat.Json, entity));
		}
	}
}