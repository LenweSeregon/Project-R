namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AbstractUITier : MonoBehaviour, IUIElement<XPTreeTier>
	{
		protected XPTreeTier m_Tier;

		public virtual void InitElement(XPTreeTier tier)
		{
			m_Tier = tier;
		}

		public virtual void UpdateElement()
		{

		}
	}
}