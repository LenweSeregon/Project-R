namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public class XPTreePrerequisite
	{
		[SerializeField] private XPTreeElementDescriptor m_Descriptor;
		[SerializeField] private int m_Level;

		public XPTreeElementDescriptor Descriptor => m_Descriptor;
		public int Level => m_Level;
	}
}
