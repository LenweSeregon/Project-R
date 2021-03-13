namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AbstractUITree : MonoBehaviour, IUIElement<XPTree>
	{
		protected XPTree m_Tree;

		public virtual void InitElement(XPTree tree)
		{
			m_Tree = tree;
		}

		public virtual void UpdateElement()
		{

		}
	}
}
