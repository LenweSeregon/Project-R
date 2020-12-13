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
		//[SerializeField] protected SerializableDictionary<Effect, TraitDescriptor> m_TraitsCombos;
		[SerializeField] protected List<TraitDescriptor> m_TraitsCombos = new List<TraitDescriptor>();

		//[SerializeField] protected SerializableDictionary<Effect, List<TraitDescriptor> m_Effects;
		[SerializeField] protected List<TraitDescriptor> m_AffectedOnAdditionTraits = new List<TraitDescriptor>();
		#endregion Fields

		#region Properties
		public string IDName => m_IDName;
		public List<TraitDescriptor> TraitsCombos => m_TraitsCombos;
		public List<TraitDescriptor> AffectedTraits => m_AffectedOnAdditionTraits;
		#endregion Properties

		public virtual void InvokeStartEffect(TraitsController owner, List<TraitsController> affectedControllers = null)
		{
			//search for combos in owner and apply corresponding effect
			//adds the combo in other.TraitsCombos if not present
			//apply effect on m_AffectedOnAdditionTraits
		}

		public virtual void InvokeEndEffect(TraitsController owner, List<TraitsController> affectedControllers = null)
		{
			//search for combos in owner and reverse corresponding effect
			//reverse effect on m_AffectedOnAdditionTraits
		}
	}
}
