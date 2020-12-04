namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;

	public class UISkillProgression : UIProgression
	{
		[SerializeField] private TextMeshProUGUI m_PointsText;

		public override void UpdateProgression(ProgressionController controller)
		{
			base.UpdateProgression(controller);
			m_PointsText.text = string.Format("Points: {0}", ((SkillProgressionController) controller).Points);
		}
	}
}