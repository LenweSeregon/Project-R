using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoAddXPTree : DemoAddXP
{
	[SerializeField] private XPTreeBuilder m_TreeBuilder;

	protected override void Start()
	{
		base.Start();
		m_TreeBuilder.BuildTrees((SkillLevelController) m_Controller);
	}

	public override void AddXp(float amount)
	{
		m_Manager.AddXP(amount, m_XPType);
		WrapperProgressionSystemUIComponent.UpdateLevel((UISkillLevel) m_UILevel, (SkillLevelController)m_Controller);
	}
}
