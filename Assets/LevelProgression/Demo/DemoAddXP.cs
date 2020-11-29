using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DemoAddXP : MonoBehaviour
{
	[SerializeField] private XPType m_XPType;
	[SerializeField] private LevelsManager m_Manager;
	[SerializeField] private LevelDescriptor m_Descriptor;
	private LevelController m_Controller;

	[SerializeField] private Image m_Image;
	[SerializeField] private TextMeshProUGUI m_XPText;
	[SerializeField] private TextMeshProUGUI m_LevelText;

	private void Start()
	{
		m_Controller = m_Manager.CreateController(m_Descriptor);
		m_Manager.AddActiveController(m_Controller);
		AddXp(0);
	}

	public void AddXp(float amount)
	{
		m_Manager.AddXP(amount, m_XPType);

		m_Image.fillAmount = m_Controller.CurrentXP / m_Controller.Threshold;
		m_XPText.text = string.Format("{0} / {1}", m_Controller.CurrentXP, m_Controller.Threshold);
		m_LevelText.text = string.Format("Level : {0}", m_Controller.Level);
	}

	private void OnDestroy()
	{
		m_Manager.RemoveActiveController(m_Controller);
	}
}
