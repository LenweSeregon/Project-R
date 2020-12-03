namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class LevelController
	{
		protected LevelDescriptor m_LevelDescriptor;
		protected float m_CurrentXP;
		protected int m_LevelCount;
		protected int m_NextThreshold;
		protected float m_Bonus = 1;
		protected UILevel m_UILevel;

		public XPType Type => m_LevelDescriptor.Type;
		public LevelDescriptor Descriptor => m_LevelDescriptor;
		public float CurrentXP => m_CurrentXP;
		public int LevelCount => m_LevelCount;
		public int Threshold => m_NextThreshold;

		public UILevel Level
		{
			get => m_UILevel;
			set => m_UILevel = value;
		}

		public LevelController(LevelDescriptor levelDescriptor)
		{
			m_LevelDescriptor = (LevelDescriptor)levelDescriptor.Clone();
			m_CurrentXP = 0;
			m_LevelCount = 1;
			m_NextThreshold = (int)m_LevelDescriptor.FindNextThreshold(m_LevelCount);
		}

		public void AddXP(float amount)
		{
			m_CurrentXP += amount * m_Bonus;
			CheckLevelGained();
		}

		private void CheckLevelGained()
		{
			int nbLevels = 0;
			while (m_LevelCount < m_LevelDescriptor.MaxLevel.Value && m_CurrentXP >= m_NextThreshold)
			{
				++m_LevelCount;
				++nbLevels;
				if (m_LevelCount == m_LevelDescriptor.MaxLevel.Value)
				{
					m_CurrentXP = 0;
				}
				else
				{
					m_CurrentXP -= m_NextThreshold;
				}
				m_NextThreshold = (int)m_LevelDescriptor.FindNextThreshold(m_LevelCount);
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