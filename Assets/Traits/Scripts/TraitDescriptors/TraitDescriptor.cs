namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "PassiveTrait", menuName = "Trait/Descriptors/PassiveTrait")]
	public class TraitDescriptor : ScriptableObject
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
		//[SerializeField] protected Dictionary<TraitDescriptor, TraitDescriptor> m_TraitsCombos;
		[SerializeField] protected List<TraitDescriptor> m_TraitsCombos = new List<TraitDescriptor>();

		//[SerializeField] protected Dictionary<Effect, List<TraitDescriptor>> m_Effects;
		[SerializeField] protected List<TraitDescriptor> m_AffectedOnAdditionTraits = new List<TraitDescriptor>();
		#endregion Fields

		#region Properties
		public string IDName => m_IDName;
		public List<TraitDescriptor> TraitsCombos => m_TraitsCombos;
		public List<TraitDescriptor> AffectedTraits => m_AffectedOnAdditionTraits;
		#endregion Properties

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
			//apply effect on m_AffectedOnAdditionTraits
		}

		public virtual void InvokeEndEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null)
		{
			Debug.Log("@TraitDescriptor/InvokeEndEffect on [" + owner.name + "] for trait [" + m_IDName + "]");
			foreach(TraitDescriptor desc in affectedControllers.Keys)
			{
				Debug.Log("Affected trait: " + desc.IDName);
				foreach(TraitsController ctl in affectedControllers[desc])
				{
					Debug.Log("Affected controller: " + ctl.name);
				}
			}
			//search for combos in owner and reverse corresponding effect
			//reverse effect on m_AffectedOnAdditionTraits
		}

		//public void CheckIfComboExists(TraitDescriptor traitDescriptor1, TraitDescriptor traitDescriptor2)
		//{
		//	if(m_TraitsCombos[traitDescriptor1] == null)
		//	{
		//		m_TraitsCombos[traitDescriptor1] = comboTraitDescriptor2;
		//	}
		//}
	}
}
