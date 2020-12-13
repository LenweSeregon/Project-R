namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TraitsController
	{
		private List<TraitInstance> m_Traits;

		public List<TraitInstance> Traits => m_Traits;

		public void AddTrait(TraitDescriptor traitDescriptor)
		{
			TraitInstance trait = new TraitInstance(traitDescriptor);
			m_Traits.Add(trait);
			//reference and call on Handler to add combos + InvokeStartEffect??
		}

		public void RemoveTrait(TraitDescriptor traitDescriptor)
		{
			foreach(TraitInstance trait in m_Traits)
			{
				if(trait.Descriptor == traitDescriptor)
				{
					m_Traits.Remove(trait);
					//call on Handler to remove combos + InvokeEndEffect??
				}
			}
		}
	}
}
