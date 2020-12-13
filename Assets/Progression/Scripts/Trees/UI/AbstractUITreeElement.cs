namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AbstractUITreeElement : MonoBehaviour
	{
		public XPTreeElement m_Element;

		public virtual void InitElement(XPTreeElement element)
		{
			m_Element = element;
		}

		public virtual void UpdateElement()
		{

		}
	}
}
