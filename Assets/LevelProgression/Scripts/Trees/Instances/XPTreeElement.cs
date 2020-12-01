namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class XPTreeElement
	{
		protected XPTreeElementDescriptor m_Descriptor;
		protected XPTreeTier m_Tier;
		protected int m_Level = 0;
		protected Sprite m_OverlayImage;

		public XPTreeElementDescriptor Descriptor => m_Descriptor;
		public XPTreeTier Tier => m_Tier;
		public int Level => m_Level;

		public XPTreeElement(XPTreeElementDescriptor descriptor, XPTreeTier tier)
		{
			m_Descriptor = descriptor;
			m_Tier = tier;
		}

		public bool CheckUnlockable(XPTree tree, SkillLevelDescriptor descriptor)
		{
			bool isUnlockable = m_Descriptor.CheckUnlockable(tree);
			if (m_Level < m_Descriptor.MaxLevel)
			{
				m_OverlayImage = isUnlockable ? descriptor.UnlockedSprite : descriptor.LockedSprite;
			}
			else
			{
				m_OverlayImage = null;
			}
			return isUnlockable;
		}

		public void Lock(SkillLevelDescriptor descriptor)
		{
			m_Level = 0;
			m_OverlayImage = descriptor.LockedSprite;
		}

		public void Unlock(SkillLevelDescriptor descriptor)
		{
			if (m_Level < m_Descriptor.MaxLevel)
			{
				if(m_Level == 0)
				{
					m_Tier.NotifyUnlockElement(this);
				}
				m_Level++;
				m_OverlayImage = descriptor.UnlockedSprite;
				m_Tier.Tree.SetPoints(-m_Descriptor.Price);
			}
		}
	}
}
