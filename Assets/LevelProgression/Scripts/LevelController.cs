using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController
{
	private LevelDescriptor m_LevelDescriptor;
	private float m_CurrentXP;
	private int m_Level;
	private int m_NextThreshold;
	private float m_Bonus = 1;

	public string Type => m_LevelDescriptor.Type;
	public LevelDescriptor Descriptor => m_LevelDescriptor;
	public float CurrentXP => m_CurrentXP;
	public int Level => m_Level;
	public int Threshold => m_NextThreshold;

	public LevelController(LevelDescriptor levelDescriptor)
	{
		m_LevelDescriptor = levelDescriptor;
		m_CurrentXP = 0;
		m_Level = 1;
		m_NextThreshold = (int) m_LevelDescriptor.FindNextThreshold(m_Level);
	}

	public void AddXP(float amount)
	{
		m_CurrentXP += amount * m_Bonus;
		CheckLevelGained();
	}

	private void CheckLevelGained()
	{
		bool levelUp = false;
		while(m_Level < m_LevelDescriptor.MaxLevel && m_CurrentXP >= m_NextThreshold)
		{
			++m_Level;
			levelUp = true;
			m_CurrentXP -= m_NextThreshold;
			m_NextThreshold = (int) m_LevelDescriptor.FindNextThreshold(m_Level);
		}
		if(levelUp)
		{
			//invoke event with nbLevelsGained
		}
	}
}
