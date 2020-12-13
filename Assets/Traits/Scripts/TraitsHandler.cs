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
		[SerializeField] private SerializableDictionary<TraitDescriptor, List<TraitsController>> m_ActiveControllers;

		public void AddController(TraitsController controller)
		{
			foreach (TraitInstance trait in controller.Traits)
			{
				TraitDescriptor descriptor = trait.Descriptor;
				m_ActiveControllers[descriptor].Add(controller); //add ref to handler in controller?
			}
		}

		public void RemoveController(TraitsController controller)
		{
			foreach (TraitInstance traitInstance in controller.Traits)
			{
				TraitDescriptor desc = traitInstance.Descriptor;
				m_ActiveControllers[desc].Remove(controller);
			}
		}

		public void InvokeEffect(string IDName, TraitsController owner)
		{
			foreach(TraitInstance trait in owner.Traits)
			{
				if(trait.IDName == IDName)
				{
					IInvokableTrait invokableTrait = (IInvokableTrait)trait.Descriptor;
					if(invokableTrait != null)
					{
						List<TraitsController> affectedControllers = new List<TraitsController>();
						foreach(TraitDescriptor desc in invokableTrait.AffectedOnInvokeTraits)
						{
							affectedControllers.AddRange(m_ActiveControllers[desc]);
						}
						invokableTrait.InvokeEffect(owner, affectedControllers);
					}
				}
			}
		}
	}
}
