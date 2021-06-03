using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;

namespace Architecture.Experiments.AmViComp.Mappers.ValueInjector.Conventions
{
	/// <summary>
	/// A Value Injecter convention to map "entity" and "model" / "view model" corresponding properties
	/// of source and destination instances.
	/// </summary>
	public sealed class Model2EntityLoopInjection
		: LoopInjection
	{
		#region Private instance fields.

		/// <summary>
		/// Indicates if corresponding properties were found, but of matching
		/// but different types (such as, an entity vs. a model or view model).
		/// </summary>
		private bool entityPropertyVsModelSituationEncountered = false;

		/// <summary>
		/// Indicates if an array or list type properties were found in both source and
		/// destination classes, differing only in the element types (i.e., entity vs. a model
		/// or a view model.)
		/// </summary>
		private bool matchingArrayPropertiesWithMatchingClassesEncountered = false;

		/// <summary>
		/// Indicates if the target property is an array (i.e., "[]") and not an "IList<>").
		/// </summary>
		private bool targetPropertyIsAnArray;

		#endregion

		#region Overridden methods.

		/// <summary>
		/// Indicates of the corresponding property types are compatible
		/// between each other or not.
		/// </summary>
		/// <param name="source">The source type.</param>
		/// <param name="target">The destination type.</param>
		/// <returns></returns>
		protected override bool MatchTypes (Type source, Type target)
		{
			// Initialize assumptions.
			this.entityPropertyVsModelSituationEncountered = false;
			this.matchingArrayPropertiesWithMatchingClassesEncountered = false;

			// Are both source and target types same?
			if (source == target)
			{
				// They're compatible.
				return (true);
			}

			// Are the source and target types an "entity vs. model / view model"
			// combination?
			if
				(
					source.Name == target.Name + "Model"
					|| source.Name == target.Name + "ViewModel"
					|| source.Name + "Model" == target.Name
					|| source.Name + "ViewModel" == target.Name
				)
			{
				// Yes. Note it down.
				this.entityPropertyVsModelSituationEncountered = true;
				return (true);
			}

			// Are the source and target types lists?
			if ((source.IsArray || source.IsConstructedGenericType) && (target.IsArray || target.IsConstructedGenericType))
			{
				// Yes. Note it down.
				this.matchingArrayPropertiesWithMatchingClassesEncountered = true;
				this.targetPropertyIsAnArray = target.IsArray;
				return (true);
			}

			// The situation is not known. Take a decision based on base
			// implementation.
			return base.MatchTypes (source, target);
		}

		/// <summary>
		/// Determines as to how to set the value in case of special situations encountered
		/// by this convention.
		/// </summary>
		/// <param name="source">The source type instance.</param>
		/// <param name="target">The target type instance.</param>
		/// <param name="sp">The property info of the source property.</param>
		/// <param name="tp">The property info of the target property.</param>
		protected override void SetValue
			(
				object source,
				object target,
				PropertyInfo sp,
				PropertyInfo tp
			)
		{
			// Were any special situations encountered?
			if
				(
					this.entityPropertyVsModelSituationEncountered == false
					&& this.matchingArrayPropertiesWithMatchingClassesEncountered == false
				)
			{
				// None. Just follow as to what base implementation does.
				base.SetValue (source, target, sp, tp);
				return;
			}

			// Are the source and destination properties "entity" and its
			// corresponding "model" or "view model"?
			if (this.entityPropertyVsModelSituationEncountered)
			{
				// Yes. Instantiate a target property type instance.
				var newTargetPropertyInstance = Activator.CreateInstance (tp.PropertyType);

				// Get the source value.
				var sourceInstancePropertyValue = sp.GetValue (source);

				// Use this Value Injecter convention, and try to inject from the source value.
				newTargetPropertyInstance.InjectFrom (new Model2EntityLoopInjection (), sourceInstancePropertyValue);

				// Set the value to the target instance.
				tp.SetValue (target, newTargetPropertyInstance);
			}

			// Are the source and destination properties arrays that match with each other?
			if (this.matchingArrayPropertiesWithMatchingClassesEncountered)
			{
				// Yes. Get the array interface (such as, IList<>, IEnumerable<>, ICollection<>, etc.
				var arrayInterface = tp.PropertyType.GetInterface (typeof (IEnumerable<>).FullName);

				// Is there one?
				if (arrayInterface != null)
				{
					// Yes. Find out the target underlying list type.
					var targetUnderlyingType = arrayInterface.GetGenericArguments () [0];
					var temporaryTargetListType = typeof (List<>).MakeGenericType (targetUnderlyingType);     // Only for facilitating adding of elements to the list.

					// Intantiate an instance of the list.
					var temporaryTargetPropertyInstance = Activator.CreateInstance (temporaryTargetListType);

					// Get the source list values.
					var sourceValuesList = sp.GetValue (source) as IEnumerable;

					// Walk through the source list of values.
					foreach (var oneItem in sourceValuesList)
					{
						// Prepare a target property instance.
						var oneElement = Activator.CreateInstance (targetUnderlyingType);

						if (targetUnderlyingType.IsValueType)
						{
							// Value types - direct assignments are Ok.
							oneElement = oneItem;
						}
						else
						{
							// Classes - inject from the source item using this convention.
							oneElement.InjectFrom (new Model2EntityLoopInjection (), oneItem);
						}

						// Add it to the target list.
						dynamic d = temporaryTargetPropertyInstance;
						d.Add ((dynamic) oneElement);
					}

					// Set the target property instance to the target instance.
					if (this.targetPropertyIsAnArray)
					{
						dynamic listAsDynamic = temporaryTargetPropertyInstance;
						dynamic arrayValues = Array.CreateInstance (targetUnderlyingType, listAsDynamic.Count);

						for (var i = 0; i < listAsDynamic.Count; i++)
						{
							arrayValues [i] = listAsDynamic [i];
						}

						tp.SetValue (target, arrayValues);
					}
					else
					{
						// The target property is an "IList<>" and not an array.
						tp.SetValue (target, Convert.ChangeType (temporaryTargetPropertyInstance, temporaryTargetListType));
					}
				}
			}
		}

		#endregion
	}
}