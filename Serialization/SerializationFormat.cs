namespace Architecture.Experiments.AmViComp.Serialization
{
	/// <summary>
	/// Represents the various serialization formats.
	/// </summary>
	public enum SerializationFormat
	{
		/// <summary>
		/// Unknown format.
		/// </summary>
		Unknown,

		/// <summary>
		/// JSON format.
		/// </summary>
		Json,

		/// <summary>
		/// XML format.
		/// </summary>
		Xml,

		/// <summary>
		/// A simple string representation of an entity.
		/// </summary>
		PrettyString
	}
}
