namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AbstractUIProgression : MonoBehaviour
	{
		protected ProgressionController m_Controller;
		public virtual void InitProgression(ProgressionController controller)
		{
			m_Controller = controller;
		}

		public virtual void UpdateProgression()
		{

		}
	}
}
