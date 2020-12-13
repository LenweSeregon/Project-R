namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Global traits are traits with effects applied when the controller does a specific action.
	/// </summary>
	[CreateAssetMenu(fileName = "GlobalTrait", menuName = "Trait/Descriptors/GlobalTrait")]
	public class GlobalTraitDescriptor : TraitDescriptor, IInvokableTrait
	{
		//[SerializeField] protected SerializableDictionary<Effect, List<TraitDescriptor> m_OnInvokeEffects;
		[SerializeField] protected List<TraitDescriptor> m_AffectedOnInvokeTraits = new List<TraitDescriptor>();

		public List<TraitDescriptor> AffectedOnInvokeTraits => m_AffectedOnAdditionTraits;

		public void InvokeEffect(TraitsController owner, List<TraitsController> affectedControllers = null)
		{
			//apply effect on affectedControllers
		}
	}
}
