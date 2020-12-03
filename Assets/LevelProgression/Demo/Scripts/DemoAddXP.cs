using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemoAddXP : MonoBehaviour
{
	[SerializeField] protected XPType m_XPType;
	[SerializeField] protected LevelsManager m_Manager;
	[SerializeField] protected LevelDescriptor m_Descriptor;
	protected LevelController m_Controller;

	[SerializeField] protected Image m_ProgressBar;
	[SerializeField] protected TextMeshProUGUI m_XPText;
	[SerializeField] protected TextMeshProUGUI m_LevelText;
	[SerializeField] protected TextMeshProUGUI m_TitleText;


	protected virtual void Start()
	{
		m_Controller = m_Manager.CreateController(m_Descriptor);
		m_Manager.AddActiveController(m_Controller);
		AddXp(0);
		m_TitleText.text = m_Controller.Descriptor.Type.Value;
	}

	public virtual void AddXp(float amount)
	{
		m_Manager.AddXP(amount, m_XPType);

		m_ProgressBar.fillAmount = m_Controller.CurrentXP / m_Controller.Threshold;
		m_XPText.text = string.Format("{0} / {1}", m_Controller.CurrentXP, m_Controller.Threshold);
		m_LevelText.text = string.Format("Level: {0}", m_Controller.Level);
	}

	private void OnDestroy()
	{
		m_Manager.RemoveActiveController(m_Controller);
	}
}
