namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class SkillProgressionController : ProgressionController
	{
		protected int m_NbPoints = 0;
		protected List<XPTree> m_Trees = new List<XPTree>();

		public int Points
		{
			get => m_NbPoints;
			set => m_NbPoints = value;
		}
		public List<XPTree> Trees => m_Trees;

		public SkillProgressionController(SkillProgressionDescriptor descriptor) : base(descriptor)
		{
			foreach (XPTreeDescriptor tree in ((SkillProgressionDescriptor)m_ProgressionDescriptor).Trees)
			{
				m_Trees.Add(new XPTree(tree, this));
			}
		}

		protected override void OnLevelIncreased(int nbLevels)
		{
			base.OnLevelIncreased(nbLevels);
			m_NbPoints += nbLevels;
			UpdateTreeElements();
		}

		protected void UpdateTreeElements()
		{
			foreach (XPTree tree in m_Trees)
			{
				List<XPTreeTier> tiers = tree.Tiers;
				foreach (XPTreeTier tier in tiers)
				{
					bool tierUnlocked = false;
					foreach (XPTreeElement elt in tier.Elements)
					{
						if (elt.CheckUnlockable(tree, (SkillProgressionDescriptor)m_ProgressionDescriptor))
						{
							tierUnlocked = true;
						}
					}
					if (tierUnlocked == false)
					{
						break;
					}
				}
			}
		}

		public void Reset()
		{
			foreach (XPTree tree in m_Trees)
			{
				tree.Reset((SkillProgressionDescriptor)m_ProgressionDescriptor);
			}
		}
	}
}
