namespace com.CompanyR.FrameworkR.TraitSystem
{
    using com.CompanyR.FrameworkR.Core;
    using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "TraitEffect", menuName = "Trait/Effects/TraitEffect")]
	public class TraitEffect : ScriptableObject
	{
		[SerializeField] private bool m_IsSelfEffect;

		public bool IsSelfEffect => m_IsSelfEffect;

		public virtual void InvokeEffect(TraitsController owner, List<TraitsController> affectedControllers)
		{
			//TODO
			if(m_IsSelfEffect)
			{
				DebugLogger.LogFormat("Invoke effect on {0} from {1}", owner.name, name);
			}
			else
			{
				foreach(TraitsController controller in affectedControllers)
				{
					DebugLogger.LogFormat("Invoke effect on {0} from {1}", owner.name, name);
				}
			}
		}

		public virtual void RevokeEffect(TraitsController owner, List<TraitsController> affectedControllers)
		{
			//TODO
			if (m_IsSelfEffect)
			{
				DebugLogger.LogFormat("Revoke effect on {0} from {1}", owner.name, name);
			}
			else
			{
				foreach (TraitsController controller in affectedControllers)
				{
					DebugLogger.LogFormat("Revoke effect on {0} from {1}", owner.name, name);
				}
			}
		}
	}
}
