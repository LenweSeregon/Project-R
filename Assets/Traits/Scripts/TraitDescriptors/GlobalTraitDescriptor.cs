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
		[SerializeField] protected Dictionary<TraitDescriptor, TraitEffect> m_OnInvokeEffects;
		//[SerializeField] protected List<TraitDescriptor> m_AffectedOnInvokeTraits = new List<TraitDescriptor>();

		protected HashSet<TraitDescriptor> m_AffectedOnInvokeTraits;

		public HashSet<TraitDescriptor> AffectedOnInvokeTraits
		{
			get
			{
				if (m_AffectedOnInvokeTraits == null)
				{
					m_AffectedOnInvokeTraits = new HashSet<TraitDescriptor>(m_OnInvokeEffects.Keys);
					m_AffectedOnInvokeTraits.Add(this);
				}
				return m_AffectedOnInvokeTraits;

			}
		}

		public void InvokeEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null)
		{
			Debug.Log("@GlobalTraitDescriptor/InvokeEffect on [" + owner.name + "] for trait [" + m_IDName + "]");
			foreach (TraitDescriptor desc in affectedControllers.Keys)
			{
				Debug.Log("Affected trait: " + desc.IDName);
				foreach (TraitsController ctl in affectedControllers[desc])
				{
					Debug.Log("Affected controller: " + ctl.name);
				}
			}

			//apply effect on affectedControllers
			foreach (KeyValuePair<TraitDescriptor, List<TraitsController>> entry in affectedControllers)
			{
				if (m_OnInvokeEffects.ContainsKey(entry.Key))
				{
					m_OnInvokeEffects[entry.Key].InvokeEffect(owner, entry.Value);
				}
			}
		}
	}
}
