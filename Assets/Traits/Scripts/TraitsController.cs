namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TraitsController : MonoBehaviour
	{
		private string m_ControllerName;
		private List<TraitInstance> m_Traits = new List<TraitInstance>();
		private List<TraitDescriptor> m_Combo = new List<TraitDescriptor>();
		private TraitsHandler m_Handler;

		public List<TraitInstance> Traits => m_Traits;
		public List<TraitDescriptor> Combo => m_Combo;
		public string ControllerName => m_ControllerName;

		public void InitControllerName(string name) => m_ControllerName = name;
		public void InitControllerHandler(TraitsHandler handler) => m_Handler = handler;

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

						TraitDescriptor combo = traitDescriptor.GetAssociatedCombo(comboDesc);
						traitInstance.Descriptor.CheckIfComboExists(traitDescriptor, combo);
						AddTrait(combo);
						m_Combo.Add(combo);
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
								TraitDescriptor combo = traitDescriptor.GetCombo(comboDesc);
								m_Handler.InvokeTraitStartEffect(traitInstance, this);
								RemoveTrait(combo);
								m_Combo.Remove(combo);
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

		public TraitInstance GetTrait(string traitName)
		{
			foreach(TraitInstance trait in m_Traits)
			{
				if(trait.Descriptor.IDName == traitName)
				{
					return trait;
				}
			}
			return null;
		}

		public void OnDestroy()
		{
			foreach(TraitInstance instance in m_Traits)
			{
				RemoveTrait(instance.Descriptor);
			}
		}
	}
}
