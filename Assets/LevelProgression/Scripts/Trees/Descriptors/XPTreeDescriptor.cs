namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using UnityEngine.UI;

    [CreateAssetMenu(fileName = "XPTreeDescriptor", menuName = "Level/Descriptors/XPTreeDescriptor")]

	public class XPTreeDescriptor : ScriptableObject
	{
		[SerializeField] private List<XPTreeTierDescriptor> m_TreeTiers = new List<XPTreeTierDescriptor>();
		[SerializeField] private Sprite m_Background;
		[SerializeField] private string m_TreeName;

		public List<XPTreeTierDescriptor> Tiers => m_TreeTiers;
		public Sprite Background => m_Background;
		public string TreeName => m_TreeName;
	}
}
