using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoXP : MonoBehaviour
{
	[SerializeField] protected ProgressionsHandler m_Handler;
	[SerializeField] protected XPUIBuilder m_Builder;
	[SerializeField] protected ProgressionDescriptor m_Descriptor;
	protected ProgressionController m_Controller;


	protected void Start()
	{
		m_Controller = m_Handler.CreateController(m_Descriptor);
		m_Builder.BuildProgression(m_Controller);
		m_Handler.AddActiveController(m_Controller);
	}

	public void AddXp(float amount)
	{
		m_Handler.AddXP(amount, m_Descriptor.Type);
	}

	private void OnDestroy()
	{
		m_Handler.RemoveActiveController(m_Controller);
	}
}
