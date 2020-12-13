using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISkillProgression : UIProgression
{
	[SerializeField] private TextMeshProUGUI m_PointsText;

	public override void InitProgression(ProgressionController controller)
	{
		base.InitProgression(controller);
	}

	public override void UpdateProgression()
	{
		base.UpdateProgression();
		m_PointsText.text = string.Format("Points: {0}", ((SkillProgressionController)m_Controller).Points);
	}
}