using AutoMapper;

namespace Architecture.Experiments.AmViComp.Mappers.AutoMapper
{
	public sealed class AutoMapperProfile
		: Profile
	{
		private static AutoMapperProfile definedInstance;
		private static object syncLocker = new object ();


		public static AutoMapperProfile DefinedInstance
		{
			get
			{
				lock (syncLocker)
				{
					if (definedInstance == null)
					{
						definedInstance = new AutoMapperProfile ();
					}
					return definedInstance;
				}
			}
		}

		private AutoMapperProfile ()
		{
		}
	}
}