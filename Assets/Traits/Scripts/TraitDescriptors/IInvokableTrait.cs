namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public interface IInvokableTrait
	{
		List<TraitDescriptor> AffectedOnInvokeTraits { get; }
		public void InvokeEffect(TraitsController owner, Dictionary<TraitDescriptor, List<TraitsController>> affectedControllers = null);
	}
}