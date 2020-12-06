namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ProgressionController
	{
		protected ProgressionDescriptor m_ProgressionDescriptor;
		protected float m_CurrentXP;
		protected int m_LevelCount;
		protected int m_NextThreshold;
		protected float m_Bonus = 1;

		public delegate void ProgressionDelegate();
		public event ProgressionDelegate OnProgressionChanged;

		public XPType Type => m_ProgressionDescriptor.Type;
		public ProgressionDescriptor Descriptor => m_ProgressionDescriptor;
		public float CurrentXP => m_CurrentXP;
		public int LevelCount => m_LevelCount;
		public int Threshold => m_NextThreshold;

		public ProgressionController(ProgressionDescriptor progressionDescriptor)
		{
			m_ProgressionDescriptor = (ProgressionDescriptor)progressionDescriptor.Clone();
			m_CurrentXP = 0;
			m_LevelCount = 1;
			m_NextThreshold = (int)m_ProgressionDescriptor.FindNextThreshold(m_LevelCount);
		}

		public void AddXP(float amount)
		{
			m_CurrentXP += amount * m_Bonus;
			CheckLevelGained();
			UpdateProgression();
		}

		public void UpdateProgression()
		{
			OnProgressionChanged();
		}

		private void CheckLevelGained()
		{
			int nbLevels = 0;
			while (m_LevelCount < m_ProgressionDescriptor.MaxLevel.Value && m_CurrentXP >= m_NextThreshold)
			{
				++m_LevelCount;
				++nbLevels;
				if (m_LevelCount == m_ProgressionDescriptor.MaxLevel.Value)
				{
					m_CurrentXP = 0;
				}
				else
				{
					m_CurrentXP -= m_NextThreshold;
				}
				m_NextThreshold = (int)m_ProgressionDescriptor.FindNextThreshold(m_LevelCount);
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