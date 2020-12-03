namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

	public class UISkillLevel : UILevel
	{
		[SerializeField] private TextMeshProUGUI m_PointsText;

		public TextMeshProUGUI PointsText => m_PointsText;

		public override void UpdateLevel(LevelController controller)
		{
			base.UpdateLevel(controller);
			m_PointsText.text = string.Format("Points: {0}", ((SkillLevelController) controller).Points);
		}
	}
}