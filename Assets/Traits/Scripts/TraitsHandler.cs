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
		[SerializeField] private Dictionary<TraitDescriptor, List<TraitsController>> m_ActiveControllers;

		public void AddController(TraitsController controller)
		{
			controller.InitController(this);
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

		private Dictionary<TraitDescriptor, List<TraitsController>> RetrieveAffectedControllers(List<TraitDescriptor> affectedListDescriptor)
		{
			Dictionary<TraitDescriptor, List<TraitsController>> affectedControllersDictionary = new Dictionary<TraitDescriptor, List<TraitsController>>();
			foreach (TraitDescriptor desc in affectedListDescriptor)
			{
				List<TraitsController> affectedControllers = new List<TraitsController>();
				affectedControllers.AddRange(m_ActiveControllers[desc]);
				affectedControllersDictionary[desc] = affectedControllers;
			}
			return affectedControllersDictionary;
		}

		public void InvokeEffect(string IDName, TraitsController owner)
		{
			foreach (TraitInstance trait in owner.Traits)
			{
				if (trait.IDName == IDName)
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
			traitInstance.Descriptor.InvokeStartEffect(owner, RetrieveAffectedControllers(traitInstance.Descriptor.AffectedTraits));
		}
		

		public void InvokeTraitEndEffect(TraitInstance traitInstance, TraitsController owner)
		{
			traitInstance.Descriptor.InvokeEndEffect(owner, RetrieveAffectedControllers(traitInstance.Descriptor.AffectedTraits));
		}

		public void AddTrait(TraitInstance traitInstance, TraitsController owner)
		{
			m_ActiveControllers[traitInstance.Descriptor].Add(owner);
		}

		public void RemoveTrait(TraitInstance traitInstance, TraitsController owner)
		{
			m_ActiveControllers[traitInstance.Descriptor].Remove(owner);
		}
	}
}
