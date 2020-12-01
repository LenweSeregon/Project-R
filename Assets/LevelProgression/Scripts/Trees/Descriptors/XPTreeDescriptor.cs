namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "XPTreeDescriptor", menuName = "Level/Descriptors/XPTreeDescriptor")]

	public class XPTreeDescriptor : ScriptableObject
	{
		[SerializeField] private List<XPTreeTierDescriptor> m_TreeTiers = new List<XPTreeTierDescriptor>();

		public List<XPTreeTierDescriptor> Tiers => m_TreeTiers;
	}
}
