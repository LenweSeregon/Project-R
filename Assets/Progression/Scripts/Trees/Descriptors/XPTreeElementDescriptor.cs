namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityAtoms.BaseAtoms;

	[CreateAssetMenu(fileName = "XPTreeElementDescriptor", menuName = "Progression/Descriptors/XPTreeElementDescriptor")]
	public class XPTreeElementDescriptor : ScriptableObject
	{
		#region Prerequisites
		[SerializeField] private List<XPTreePrerequisite> m_Prerequisites = new List<XPTreePrerequisite>();
		[SerializeField] private int m_NbTotalPrerequisites = 0;
		[SerializeField] private int m_Price = 1;
		#endregion Prerequisites

		#region ID Fields
		[SerializeField] private Sprite m_Sprite;
		[SerializeField] private string m_ElementName;
		[SerializeField] private string m_Description;
		[SerializeField] private int m_MaxLevel = 1;
		#endregion ID Fields

		//To-Do: Classe effect avec tableau de niveau

		public Sprite SkillSprite => m_Sprite;
		public string Name => m_ElementName;
		public string Description => m_Description;
		public int MaxLevel => m_MaxLevel;
		public int Price => m_Price;

		public bool CheckUnlockable(XPTree tree)
		{
			int unlockedPrerequisites = 0;
			List<XPTreeElement> unlockedElements = tree.UnlockedElements;

			if (m_Price > tree.Controller.Points) return false;

			if (unlockedElements.Count >= m_NbTotalPrerequisites)
			{
				foreach (XPTreeElement elt1 in unlockedElements)
				{
					XPTreeElementDescriptor descriptor = elt1.Descriptor;
					foreach (XPTreePrerequisite pr in m_Prerequisites)
					{
						if (descriptor == pr.Descriptor && elt1.Level == pr.Level)
						{
							++unlockedPrerequisites;
						}
					}
				}
				if (unlockedPrerequisites == m_Prerequisites.Count)
				{
					return true;
				}
			}
			return false;
		}
	}
}
