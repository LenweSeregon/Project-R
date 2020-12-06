namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;


	/// <summary>
	/// Builds the UI associated to a skill system.
	/// This should be placed on the root of the skill trees.
	/// </summary>

	public class XPTreeUIBuilder : XPUIBuilder
	{
		[SerializeField] private UITree m_TreePrefab;
		[SerializeField] private UITier m_TierPrefab;
		[SerializeField] private UITreeElement m_ElementPrefab;
		[SerializeField] private Transform m_TreesContainer;

		public override void BuildProgression(ProgressionController controller)
		{
			base.BuildProgression(controller);
			SkillProgressionController skillController = (SkillProgressionController) controller;
			SkillProgressionDescriptor descriptor = (SkillProgressionDescriptor)skillController.Descriptor;
			foreach (XPTree tree in skillController.Trees)
			{
				UITree uiTree = Instantiate(m_TreePrefab, m_TreesContainer);
				uiTree.InitTree(tree);

				foreach (XPTreeTier tier in tree.Tiers)
				{
					UITier uiTier = Instantiate(m_TierPrefab, uiTree.TiersContainer.transform);
					uiTier.InitTier(tier);
					foreach (XPTreeElement element in tier.Elements)
					{
						UITreeElement uiElement = Instantiate(m_ElementPrefab, uiTier.transform);
						uiElement.InitElement(element);
					}
				}
			}
		}
	}
}
