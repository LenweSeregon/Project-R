namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "TraitHandler", menuName = "Trait/Handler")]
	public class TraitsHandler : ScriptableObject
	{
		/// <summary>
		/// List of controllers that contain the associated trait.
		/// </summary>
		[SerializeField] private Dictionary<TraitDescriptor, List<TraitsController>> m_ActiveControllers = new Dictionary<TraitDescriptor, List<TraitsController>>();

		/// <summary>
		/// Mappers for TraitDescriptors so that when a trait is created, we can apply all the related effects on it.
		/// </summary>
		private Dictionary<TraitDescriptor, List<TraitDescriptor>> m_DescriptorsMapper = new Dictionary<TraitDescriptor, List<TraitDescriptor>>();

		public void AddController(TraitsController controller)
		{
			controller.InitControllerHandler(this);
			foreach (TraitInstance traitInstance in controller.Traits)
			{
				AddTrait(traitInstance, controller);
			}
		}

		public void RemoveController(TraitsController controller)
		{
			foreach (TraitInstance traitInstance in controller.Traits)
			{
				RemoveTrait(traitInstance, controller);
			}
		}

		private Dictionary<TraitDescriptor, List<TraitsController>> RetrieveAffectedControllers(HashSet<TraitDescriptor> affectedListDescriptor)
		{
			Dictionary<TraitDescriptor, List<TraitsController>> affectedControllersDictionary = new Dictionary<TraitDescriptor, List<TraitsController>>();
			foreach (TraitDescriptor desc in affectedListDescriptor)
			{
				List<TraitsController> affectedControllers = new List<TraitsController>();
				affectedControllers.AddRange(m_ActiveControllers[desc]);

				if (affectedControllersDictionary.ContainsKey(desc) == false)
				{
					affectedControllersDictionary.Add(desc, affectedControllers);
				}
			}
			return affectedControllersDictionary;
		}

		public void InvokeEffect(string traitIDName, TraitsController owner)
		{
			foreach (TraitInstance trait in owner.Traits)
			{
				if (trait.IDName == traitIDName)
				{
					IInvokableTrait invokableTrait = (IInvokableTrait)trait.Descriptor;
					if (invokableTrait != null)
					{
						invokableTrait.InvokeEffect(owner, RetrieveAffectedControllers(invokableTrait.AffectedOnInvokeTraits));
					}
				}
			}
		}

		public void InvokeTraitStartEffect(TraitInstance traitInstance, TraitsController owner)
		{
			TraitDescriptor traitDescriptor = traitInstance.Descriptor;
			traitDescriptor.InvokeStartEffect(owner, RetrieveAffectedControllers(traitDescriptor.AffectedTraits));

			//If the trait is added for the first time, add its affected traits to the mapper.
			if (m_ActiveControllers.ContainsKey(traitDescriptor) == false)
			{
				foreach (TraitDescriptor affectedTrait in traitDescriptor.AffectedTraits)
				{
					if (m_DescriptorsMapper.ContainsKey(affectedTrait) == false)
					{
						m_DescriptorsMapper.Add(affectedTrait, new List<TraitDescriptor>());
					}
					m_DescriptorsMapper[affectedTrait].Add(traitDescriptor);
				}
			}

			//Update every affected controllers with this new trait that has been added.
			if (m_DescriptorsMapper.ContainsKey(traitDescriptor))
			{
				foreach (TraitDescriptor affectedTrait in m_DescriptorsMapper[traitDescriptor])
				{
					foreach (TraitsController affectedController in m_ActiveControllers[affectedTrait])
					{
						Dictionary<TraitDescriptor, List<TraitsController>> traitDictionary = new Dictionary<TraitDescriptor, List<TraitsController>>();
						traitDictionary.Add(traitDescriptor, new List<TraitsController> { owner });
						affectedTrait.InvokeStartEffect(affectedController, traitDictionary);
					}
				}
			}
		}


		public void InvokeTraitEndEffect(TraitInstance traitInstance, TraitsController owner)
		{
			traitInstance.Descriptor.InvokeEndEffect(owner, RetrieveAffectedControllers(traitInstance.Descriptor.AffectedTraits));
		}

		public void AddTrait(TraitInstance traitInstance, TraitsController owner)
		{
			if (m_ActiveControllers.ContainsKey(traitInstance.Descriptor) == false)
			{
				m_ActiveControllers.Add(traitInstance.Descriptor, new List<TraitsController>());
			}
			m_ActiveControllers[traitInstance.Descriptor].Add(owner);
		}

		public void RemoveTrait(TraitInstance traitInstance, TraitsController owner)
		{
			if (m_ActiveControllers.ContainsKey(traitInstance.Descriptor))
			{
				m_ActiveControllers[traitInstance.Descriptor].Remove(owner);
			}
		}
	}
}
