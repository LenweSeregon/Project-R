namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Interactive traits are traits with effects applied when the TraitController interacts directly with other controllers.
	/// </summary>
	[CreateAssetMenu(fileName = "InteractiveTrait", menuName = "Trait/Descriptors/InteractiveTrait")]
	public class InteractiveTraitDescriptor : TraitDescriptor, IInvokableTrait
	{
		//[SerializeField] protected Dictionary<Effect, List<TraitDescriptor>> m_OnInvokeEffects;
		[SerializeField] protected List<TraitDescriptor> m_AffectedOnInvokeTraits = new List<TraitDescriptor>();

		public List<TraitDescriptor> AffectedOnInvokeTraits => m_AffectedOnAdditionTraits;

		public void InvokeEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null)
		{
			Debug.Log("@InteractiveTraitDescriptor/InvokeEffect on [" + owner.name + "] for trait [" + m_IDName + "]");
			foreach (TraitDescriptor desc in affectedControllers.Keys)
			{
				Debug.Log("Affected trait: " + desc.IDName);
				foreach (TraitsController ctl in affectedControllers[desc])
				{
					Debug.Log("Affected controller: " + ctl.name);
				}
			}
			//apply effect on affectedControllers
		}
	}
}
