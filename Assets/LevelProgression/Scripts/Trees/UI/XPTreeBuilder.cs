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

    public class XPTreeBuilder : MonoBehaviour
	{
		[SerializeField] private UITree m_TreePrefab;
		[SerializeField] private UITier m_TierPrefab;
		[SerializeField] private UIElement m_ElementPrefab;

		public void BuildTrees(SkillLevelController controller)
		{
			SkillLevelDescriptor descriptor = (SkillLevelDescriptor) controller.Descriptor;
			foreach(XPTree tree in controller.Trees)
			{
				UITree uiTree = Instantiate(m_TreePrefab, transform);
				WrapperProgressionSystemUIComponent.InitTree(uiTree, tree);
				
				foreach(XPTreeTier tier in tree.Tiers)
				{
					UITier uiTier = Instantiate(m_TierPrefab, uiTree.TiersContainer.transform);
					WrapperProgressionSystemUIComponent.InitTier(uiTier, tier);
					foreach (XPTreeElement element in tier.Elements)
					{
						UIElement uiElement = Instantiate(m_ElementPrefab, uiTier.transform);
						WrapperProgressionSystemUIComponent.InitElement(uiElement, element, descriptor);
					}
				}
			}
		}
	}
}
