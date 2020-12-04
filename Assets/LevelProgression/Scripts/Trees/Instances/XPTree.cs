namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class XPTree
	{
		private SkillProgressionController m_Controller;
		private XPTreeDescriptor m_Descriptor;
		private List<XPTreeTier> m_Tiers = new List<XPTreeTier>();
		private List<XPTreeElement> m_UnlockedElements = new List<XPTreeElement>();

		public XPTreeDescriptor Descriptor => m_Descriptor;
		public List<XPTreeTier> Tiers => m_Tiers;
		public List<XPTreeElement> UnlockedElements => m_UnlockedElements;
		public SkillProgressionController Controller => m_Controller;

		public XPTree(XPTreeDescriptor descriptor, SkillProgressionController controller)
		{
			m_Controller = controller;
			m_Descriptor = descriptor;
			foreach (XPTreeTierDescriptor tierDescriptor in descriptor.Tiers)
			{
				m_Tiers.Add(new XPTreeTier(tierDescriptor, this));
			}
		}

		public void Reset(SkillProgressionDescriptor descriptor)
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
			m_Controller.Points += value;
		}
	}
}
