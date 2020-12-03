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
	[SerializeField] protected UILevel m_UILevel;
	protected LevelController m_Controller;

	protected virtual void Start()
	{
		m_Controller = m_Manager.CreateController(m_Descriptor);
		m_Manager.AddActiveController(m_Controller);
		WrapperProgressionSystemUIComponent.InitLevel(m_UILevel, m_Controller);
		AddXp(0);
	}

	public virtual void AddXp(float amount)
	{
		m_Manager.AddXP(amount, m_XPType);
		WrapperProgressionSystemUIComponent.UpdateLevel(m_UILevel, m_Controller);
	}

	private void OnDestroy()
	{
		m_Manager.RemoveActiveController(m_Controller);
	}
}
