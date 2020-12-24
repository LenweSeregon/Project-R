namespace com.CompanyR.FrameworkR.TraitSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "TraitEffect", menuName = "Trait/Effects/TraitEffect")]
	public class TraitEffect : ScriptableObject
	{
		public virtual void InvokeEffect(TraitsController affectedController)
		{
			//TODO
		}

		public virtual void RevokeEffect(TraitsController affectedController)
		{
			//TODO
		}
	}
}
