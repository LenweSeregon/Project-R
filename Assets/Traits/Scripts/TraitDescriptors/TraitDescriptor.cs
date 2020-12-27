namespace com.CompanyR.FrameworkR.TraitSystem
{
    using Sirenix.OdinInspector;
    using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "PassiveTrait", menuName = "Trait/Descriptors/PassiveTrait")]
	public class TraitDescriptor : SerializedScriptableObject
	{
		#region Fields
		/// <summary>
		/// This identifies the trait.
		/// </summary>
		[SerializeField] protected string m_IDName;

		/// <summary>
		/// A list of trait descriptors updated when this descriptor is added/removed.
		/// This can be used to create combos.
		/// </summary>
		[SerializeField] protected Dictionary<TraitDescriptor, TraitDescriptor> m_ComboEffects;
		//[SerializeField] protected List<TraitDescriptor> m_TraitsCombos = new List<TraitDescriptor>();

		[SerializeField] protected Dictionary<TraitDescriptor, TraitEffect> m_OnAdditionInvokeEffects;
		//[SerializeField] protected List<TraitDescriptor> m_AffectedOnAdditionTraits = new List<TraitDescriptor>();

		protected HashSet<TraitDescriptor> m_AffectedTraits;
		protected List<TraitDescriptor> m_TraitsCombo;
		#endregion Fields

		#region Properties
		public string IDName => m_IDName;
		public List<TraitDescriptor> TraitsCombo
		{
			get
			{
				if(m_TraitsCombo == null)
				{
					m_TraitsCombo = new List<TraitDescriptor>(m_ComboEffects.Keys);
				}
				return m_TraitsCombo;
			}
		}
		public HashSet<TraitDescriptor> AffectedTraits
		{
			get
			{
				if (m_AffectedTraits == null)
				{
					m_AffectedTraits = new HashSet<TraitDescriptor>(m_OnAdditionInvokeEffects.Keys);
				}
				return m_AffectedTraits;

			}
		}
		#endregion Properties

		public TraitDescriptor GetCombo(TraitDescriptor traitToCombo)
		{
			if(m_ComboEffects.ContainsKey(traitToCombo))
			{
				return m_ComboEffects[traitToCombo];
			}
			return null;
		}

		/// <summary>
		/// Called when a trait is added to a controller.
		/// </summary>
		/// <param name="owner">The controller that gained the trait.</param>
		/// <param name="affectedControllers">Dictionary with each controller affected by this trait, sorted by their trait which react with this one.</param>
		public virtual void InvokeStartEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null)
		{
			Debug.Log("@TraitDescriptor/InvokeStartEffect on [" + owner.name + "] for trait [" + m_IDName + "]");

			//search for combos in owner and apply corresponding effect
			//adds the combo in other.TraitsCombos if not present

			foreach (KeyValuePair<TraitDescriptor, List<TraitsController>> entry in affectedControllers)
			{
				if (m_OnAdditionInvokeEffects.ContainsKey(entry.Key))
				{
					m_OnAdditionInvokeEffects[entry.Key].InvokeEffect(owner);
					foreach (TraitsController controller in entry.Value)
					{
						m_OnAdditionInvokeEffects[entry.Key].InvokeEffect(controller);
					}
				}
			}
		}

		public virtual void InvokeEndEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null)
		{
			Debug.Log("@TraitDescriptor/InvokeEndEffect on [" + owner.name + "] for trait [" + m_IDName + "]");
			foreach (TraitDescriptor desc in affectedControllers.Keys)
			{
				Debug.Log("Affected trait: " + desc.IDName);
				foreach (TraitsController ctl in affectedControllers[desc])
				{
					Debug.Log("Affected controller: " + ctl.name);
				}
			}
			//search for combos in owner and reverse corresponding effect
			//reverse effect on m_AffectedOnAdditionTraits

			foreach (KeyValuePair<TraitDescriptor, List<TraitsController>> entry in affectedControllers)
			{
				if (m_OnAdditionInvokeEffects.ContainsKey(entry.Key))
				{
					m_OnAdditionInvokeEffects[entry.Key].InvokeEffect(owner);
					foreach (TraitsController controller in entry.Value)
					{
						m_OnAdditionInvokeEffects[entry.Key].RevokeEffect(controller);
					}
				}
			}
		}

		public void CheckIfComboExists(TraitDescriptor traitToCombo, TraitDescriptor combo)
		{
			if (m_ComboEffects.ContainsKey(traitToCombo) == false)
			{
				m_ComboEffects.Add(traitToCombo, combo);
			}
		}

		public TraitDescriptor GetAssociatedCombo(TraitDescriptor traitDescriptor)
		{
			if(m_ComboEffects.ContainsKey(traitDescriptor) == true)
			{
				return m_ComboEffects[traitDescriptor];
			}
			return null;
		}
	}
}
