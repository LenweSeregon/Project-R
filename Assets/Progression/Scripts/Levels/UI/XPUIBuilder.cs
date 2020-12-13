namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class XPUIBuilder : MonoBehaviour
	{
		[SerializeField] protected UIProgression m_ProgressionPrefab;
		[SerializeField] protected Transform m_ProgressionRoot;
		protected UIProgression m_UIProgression;

		public virtual void BuildProgression(ProgressionController controller)
		{
			GameObject go = new GameObject(controller.Descriptor.Name);
			m_UIProgression = Instantiate(m_ProgressionPrefab, m_ProgressionRoot);
			m_UIProgression.InitProgression(controller);
		}

		public void DestroyUIProgression()
		{
			Destroy(m_ProgressionRoot.parent);
		}
	}
}
