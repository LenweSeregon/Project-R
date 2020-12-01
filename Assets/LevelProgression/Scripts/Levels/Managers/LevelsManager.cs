namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityAtoms;

	[CreateAssetMenu(fileName = "LevelsManager", menuName = "Level/Manager")]
	public class LevelsManager : ScriptableObject
	{
		[SerializeField] protected List<LevelDescriptor> m_LevelDescriptors = new List<LevelDescriptor>();

		protected List<LevelController> m_ActiveControllers = new List<LevelController>();

		public LevelController CreateController(LevelDescriptor levelDescriptor)
		{
			return levelDescriptor.CreateController();
		}

		public void AddXP(float amount, XPType xpType)
		{
			foreach (LevelController ctl in m_ActiveControllers)
			{
				if (ctl.Type.Value == xpType.Value)
				{
					ctl.AddXP(amount);
				}
			}
		}

		public void AddActiveController(LevelController levelController)
		{
			m_ActiveControllers.Add(levelController);
		}

		public void RemoveActiveController(LevelController levelController)
		{
			m_ActiveControllers.Remove(levelController);
		}
	}

}