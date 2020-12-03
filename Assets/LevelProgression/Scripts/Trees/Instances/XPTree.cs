namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class XPTree
	{
		private XPTreeDescriptor m_Descriptor;
		private List<XPTreeTier> m_Tiers = new List<XPTreeTier>();
		private List<XPTreeElement> m_UnlockedElements = new List<XPTreeElement>();
		private int m_Points = 0;

		public XPTreeDescriptor Descriptor => m_Descriptor;
		public List<XPTreeTier> Tiers => m_Tiers;
		public List<XPTreeElement> UnlockedElements => m_UnlockedElements;
		public int Points => m_Points;

		public XPTree(XPTreeDescriptor descriptor)
		{
			m_Descriptor = descriptor;
			foreach (XPTreeTierDescriptor tierDescriptor in descriptor.Tiers)
			{
				m_Tiers.Add(new XPTreeTier(tierDescriptor, this));
			}
		}

		public void Reset(SkillLevelDescriptor descriptor)
		{
			foreach (XPTreeTier tier in m_Tiers)
			{
				foreach (XPTreeElement elt in tier.Elements)
				{
					elt.Lock(descriptor);
				}
			}
		}

		public void NotifyUnlockElement(XPTreeElement element)
		{
			m_UnlockedElements.Add(element);
		}

		public void SetPoints(int value)
		{
			m_Points += value;
		}
	}
}
