namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityAtoms;

	[CreateAssetMenu(fileName = "ProgressionsHandler", menuName = "Progression/Handler")]
	public class ProgressionsHandler : ScriptableObject
	{
		protected List<ProgressionController> m_ActiveControllers = new List<ProgressionController>();

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
				}
			}
		}

		public void AddActiveController(ProgressionController progressionController)
		{
			m_ActiveControllers.Add(progressionController);
		}

		public void RemoveActiveController(ProgressionController progressionController)
		{
			m_ActiveControllers.Remove(progressionController);
		}
	}

}