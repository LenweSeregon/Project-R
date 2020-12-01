namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public class XPTreeTierDescriptor
	{
		[SerializeField]
		private List<XPTreeElementDescriptor> m_Elements = new List<XPTreeElementDescriptor>();

		public List<XPTreeElementDescriptor> Elements => m_Elements;
	}
}
