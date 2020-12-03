using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoAddXPTree : DemoAddXP
{
	[SerializeField] private TextMeshProUGUI m_PointsText;
	[SerializeField] private XPTreeBuilder m_TreeBuilder;

	protected override void Start()
	{
		base.Start();
		m_TreeBuilder.BuildTrees((SkillLevelController) m_Controller);
	}

	public override void AddXp(float amount)
	{
		base.AddXp(amount);
		m_PointsText.text = string.Format("Points: {0}", ((SkillLevelController) m_Controller).Points);
	}
}
