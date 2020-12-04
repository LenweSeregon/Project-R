namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityAtoms;

	[CreateAssetMenu(fileName = "LevelsManager", menuName = "Progression/Manager")]
	public class LevelsManager : ScriptableObject
	{
		[SerializeField] protected WrapperProgressionSystemUIComponent m_Wrapper;
		[SerializeField] protected List<ProgressionDescriptor> m_ProgressionDescriptors = new List<ProgressionDescriptor>();

		protected List<ProgressionController> m_ActiveControllers = new List<ProgressionController>();

		public WrapperProgressionSystemUIComponent Wrapper => m_Wrapper;

		public ProgressionController CreateController(ProgressionDescriptor progressionDescriptor)
		{
			return progressionDescriptor.CreateController();
		}

		public void AddXP(float amount, XPType xpType)
		{
			foreach (ProgressionController ctl in m_ActiveControllers)
			{
				if (ctl.Type.Value == xpType.Value)
				{
					ctl.AddXP(amount);
					m_Wrapper.UpdateProgression(ctl);
				}
			}
		}

		public void AddActiveController(ProgressionController progressionController, UIProgression uiProgression)
		{
			m_ActiveControllers.Add(progressionController);
			m_Wrapper.InitProgression(uiProgression, progressionController);
		}

		public void RemoveActiveController(ProgressionController progressionController)
		{
			m_ActiveControllers.Remove(progressionController);
		}

		public void UpdateProgression(ProgressionController progressionController)
		{
			m_Wrapper.UpdateProgression(progressionController);
		}
	}

}