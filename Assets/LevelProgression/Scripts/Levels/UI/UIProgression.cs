namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIProgression : MonoBehaviour
	{
		[SerializeField] protected TextMeshProUGUI m_XPText;
		[SerializeField] protected TextMeshProUGUI m_LevelText;
		[SerializeField] protected TextMeshProUGUI m_TitleText;
		[SerializeField] protected Image m_ProgressBar;
		private ProgressionController m_Controller;

		public virtual void InitProgression(ProgressionController controller)
		{
			m_TitleText.text = controller.Descriptor.Type.Value;
			UpdateProgression(controller);
		}

		public virtual void UpdateProgression(ProgressionController controller)
		{
			m_ProgressBar.fillAmount = controller.CurrentXP / controller.Threshold;
			m_XPText.text = string.Format("{0} / {1}", controller.CurrentXP, controller.Threshold);
			m_LevelText.text = string.Format("Level: {0}", controller.LevelCount);
		}
	}
}
