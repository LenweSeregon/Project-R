namespace com.CompanyR.FrameworkR.ProgressSystem
{
    using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

	public class XPTreeElement
	{
		protected XPTreeElementDescriptor m_Descriptor;
		protected XPTreeTier m_Tier;
		protected int m_Level = 0;
		protected Sprite m_OverlayImage;
		protected UITreeElement m_UIElement;

		public delegate void TreeElementDelegate();
		public event TreeElementDelegate OnLevelIncreased;
		public event TreeElementDelegate OnLevelDecreased;

		public XPTreeElementDescriptor Descriptor => m_Descriptor;
		public XPTreeTier Tier => m_Tier;
		public int Level => m_Level;

		public SkillProgressionDescriptor ProgressionDescriptor => (SkillProgressionDescriptor ) Tier.Tree.Controller.Descriptor;

		public UITreeElement Element
		{
			get => m_UIElement;
			set => m_UIElement = value;
		}

		public XPTreeElement(XPTreeElementDescriptor descriptor, XPTreeTier tier)
		{
			m_Descriptor = descriptor;
			m_Tier = tier;
		}

		public bool CheckUnlockable(XPTree tree, SkillProgressionDescriptor descriptor)
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

		public void Lock()
		{
			m_Tier.Tree.AddPoints(m_Level * m_Descriptor.Price);
			m_Level = 0;
			m_OverlayImage = ProgressionDescriptor.LockedSprite;
		}

		public void IncreaseLevel()
		{
			if (m_Level < m_Descriptor.MaxLevel && m_Tier.Tree.Controller.Points >= m_Descriptor.Price)
			{
				if (m_Level == 0)
				{
					m_Tier.NotifyUnlockElement(this);
				}
				m_Level++;
				m_OverlayImage = ProgressionDescriptor.UnlockedSprite;
				m_Tier.Tree.AddPoints(-m_Descriptor.Price);
				OnLevelIncreased();
			}
		}

		public void DecreaseLevel()
		{
			if(m_Level > 0)
			{
				m_Level--;
				if(m_Level == 0)
				{
					m_OverlayImage = ProgressionDescriptor.LockedSprite;
				}
				m_Tier.Tree.AddPoints(m_Descriptor.Price);
				OnLevelDecreased();
			}
		}
	}
}
