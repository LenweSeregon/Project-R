namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class XPBuilder : MonoBehaviour
	{
		[SerializeField] protected LevelsManager m_Manager;
		[SerializeField] protected ProgressionDescriptor m_Descriptor;
		[SerializeField] protected UIProgression m_ProgressionPrefab;
		[SerializeField] protected Transform m_ProgressionRoot;
		protected ProgressionController m_Controller;
		protected UIProgression m_UIProgression;

		protected void Start()
		{
			m_Controller = m_Manager.CreateController(m_Descriptor);
			BuildProgression();
		}

		protected virtual void BuildProgression()
		{
			GameObject go = new GameObject(m_Descriptor.Name);
			m_UIProgression = Instantiate(m_ProgressionPrefab, m_ProgressionRoot);
			m_Manager.AddActiveController(m_Controller, m_UIProgression);
		}

		public virtual void AddXp(float amount)
		{
			m_Manager.AddXP(amount, m_Descriptor.Type);
		}

		private void OnDestroy()
		{
			m_Manager.RemoveActiveController(m_Controller);
		}
	}
}
