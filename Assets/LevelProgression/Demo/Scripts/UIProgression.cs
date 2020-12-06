using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProgression : AbstractUIProgression
{
	[SerializeField] protected TextMeshProUGUI m_XPText;
	[SerializeField] protected TextMeshProUGUI m_LevelText;
	[SerializeField] protected TextMeshProUGUI m_TitleText;
	[SerializeField] protected Image m_ProgressBar;

	public override void InitProgression(ProgressionController controller)
	{
		base.InitProgression(controller);
		m_TitleText.text = controller.Descriptor.Type.Value;
		m_Controller = controller;
		controller.OnProgressionChanged += UpdateProgression;
		UpdateProgression();
	}

	public override void UpdateProgression()
	{
		base.UpdateProgression();
		m_ProgressBar.fillAmount = m_Controller.CurrentXP / m_Controller.Threshold;
		m_XPText.text = string.Format("{0} / {1}", m_Controller.CurrentXP, m_Controller.Threshold);
		m_LevelText.text = string.Format("Level: {0}", m_Controller.LevelCount);
	}
}