namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UILevel : MonoBehaviour
	{
		[SerializeField] protected TextMeshProUGUI m_XPText;
		[SerializeField] protected TextMeshProUGUI m_LevelText;
		[SerializeField] protected TextMeshProUGUI m_TitleText;
		[SerializeField] protected Image m_ProgressBar;

		private LevelController m_Controller;

		public TextMeshProUGUI XPText => m_XPText;
		public TextMeshProUGUI LevelText => m_LevelText;
		public TextMeshProUGUI TitleText => m_TitleText;
		public Image ProgressBar => m_ProgressBar;

		public virtual void UpdateLevel(LevelController controller)
		{
			m_ProgressBar.fillAmount = controller.CurrentXP / controller.Threshold;
			m_XPText.text = string.Format("{0} / {1}", controller.CurrentXP, controller.Threshold);
			m_LevelText.text = string.Format("Level: {0}", controller.LevelCount);
		}
	}
}
