namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TraitsController : MonoBehaviour
	{
		private List<TraitInstance> m_Traits;
		private TraitsHandler m_Handler;

		public List<TraitInstance> Traits => m_Traits;

		public void InitController(TraitsHandler handler) => m_Handler = handler;

		public void AddTrait(TraitDescriptor traitDescriptor)
		{
			TraitInstance trait = new TraitInstance(traitDescriptor);
			bool comboActivated = false;
			foreach (TraitInstance traitInstance in m_Traits)
			{
				foreach (TraitDescriptor comboDesc in traitDescriptor.TraitsCombo)
				{
					if (traitInstance.Descriptor == comboDesc)
					{
						comboActivated = true;
						m_Handler.InvokeTraitEndEffect(traitInstance, this);

						traitInstance.Descriptor.CheckIfComboExists(traitDescriptor, traitDescriptor.GetAssociatedCombo(comboDesc));
						AddTrait(traitDescriptor.GetAssociatedCombo(comboDesc));
					}
				}
			}

			if (comboActivated == false)
			{
				m_Handler.InvokeTraitStartEffect(trait, this);
			}
			m_Handler.AddTrait(trait, this);
			m_Traits.Add(trait);
		}


		public void RemoveTrait(TraitDescriptor traitDescriptor)
		{
			foreach (TraitInstance trait in m_Traits)
			{
				if (trait.Descriptor == traitDescriptor)
				{
					bool comboActivated = false;
					foreach (TraitInstance traitInstance in m_Traits)
					{
						foreach (TraitDescriptor comboDesc in traitDescriptor.TraitsCombo)
						{
							if (traitInstance.Descriptor == comboDesc)
							{
								comboActivated = true;
								m_Handler.InvokeTraitStartEffect(traitInstance, this);
								RemoveTrait(traitDescriptor.GetCombo(comboDesc));
							}
						}
					}

					if (comboActivated == false)
					{
						m_Handler.InvokeTraitEndEffect(trait, this);
					}
					m_Handler.RemoveTrait(trait, this);
					m_Traits.Remove(trait);
				}
			}
		}
	}
}
