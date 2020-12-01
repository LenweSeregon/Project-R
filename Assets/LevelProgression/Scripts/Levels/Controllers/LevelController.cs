namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class LevelController
	{
		protected LevelDescriptor m_LevelDescriptor;
		protected float m_CurrentXP;
		protected int m_Level;
		protected int m_NextThreshold;
		protected float m_Bonus = 1;

		public XPType Type => m_LevelDescriptor.Type;
		public LevelDescriptor Descriptor => m_LevelDescriptor;
		public float CurrentXP => m_CurrentXP;
		public int Level => m_Level;
		public int Threshold => m_NextThreshold;

		public LevelController(LevelDescriptor levelDescriptor)
		{
			m_LevelDescriptor = (LevelDescriptor)levelDescriptor.Clone();
			m_CurrentXP = 0;
			m_Level = 1;
			m_NextThreshold = (int)m_LevelDescriptor.FindNextThreshold(m_Level);
		}

		public void AddXP(float amount)
		{
			m_CurrentXP += amount * m_Bonus;
			CheckLevelGained();
		}

		private void CheckLevelGained()
		{
			int nbLevels = 0;
			while (m_Level < m_LevelDescriptor.MaxLevel.Value && m_CurrentXP >= m_NextThreshold)
			{
				++m_Level;
				++nbLevels;
				if (m_Level == m_LevelDescriptor.MaxLevel.Value)
				{
					m_CurrentXP = 0;
				}
				else
				{
					m_CurrentXP -= m_NextThreshold;
				}
				m_NextThreshold = (int)m_LevelDescriptor.FindNextThreshold(m_Level);
			}
			if (nbLevels > 0)
			{
				OnLevelIncreased(nbLevels);
			}
		}

		protected virtual void OnLevelIncreased(int nbLevels)
		{
			//invoke events
		}
	}

}