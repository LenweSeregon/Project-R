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

	public class XPTreeBuilder : XPBuilder
	{
		[SerializeField] private UITree m_TreePrefab;
		[SerializeField] private UITier m_TierPrefab;
		[SerializeField] private UIElement m_ElementPrefab;
		[SerializeField] private Transform m_TreesContainer;

		protected override void BuildProgression()
		{
			base.BuildProgression();
			SkillProgressionController controller = (SkillProgressionController)m_Controller;
			WrapperProgressionSystemUIComponent wrapper = m_Manager.Wrapper;
			SkillProgressionDescriptor descriptor = (SkillProgressionDescriptor)controller.Descriptor;
			foreach (XPTree tree in controller.Trees)
			{
				UITree uiTree = Instantiate(m_TreePrefab, m_TreesContainer);
				wrapper.InitTree(uiTree, tree);

				foreach (XPTreeTier tier in tree.Tiers)
				{
					UITier uiTier = Instantiate(m_TierPrefab, uiTree.TiersContainer.transform);
					wrapper.InitTier(uiTier, tier);
					foreach (XPTreeElement element in tier.Elements)
					{
						UIElement uiElement = Instantiate(m_ElementPrefab, uiTier.transform);
						wrapper.InitElement(uiElement, element, descriptor);
						//element.OnLockEvent += this.UpdateTree
					}
				}
			}
		}

		/*public override void AddXp(float amount)
		{
			m_Manager.AddXP(amount, m_XPType);
			m_Wrapper.UpdateProgression((UISkillLevel)m_UILevel, (SkillLevelController)m_Controller); //à bouger dans le manager
		}*/
	}
}
