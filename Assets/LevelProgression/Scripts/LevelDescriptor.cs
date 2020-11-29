using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

[CreateAssetMenu(fileName = "LevelDescriptor", menuName = "Level/Descriptor")]
public class LevelDescriptor : ScriptableObject
{
	[SerializeField] private FloatVariable m_BaseXP;
	[SerializeField] private IntVariable m_MaxLevel;
	[SerializeField] private float m_IncreaseRatio;
	[SerializeField] private string m_DescriptorName;
	[SerializeField] private XPType m_XPType;

	public float BaseXP => m_BaseXP.Value;
	public int MaxLevel => m_MaxLevel.Value;
	public string Name => m_DescriptorName;
	public string Type => m_XPType.Value;

	public float FindNextThreshold(int level)
	{
		float amount = m_BaseXP.Value;
		for(int i = 2; i <= level; ++i)
		{
			amount *= m_IncreaseRatio;
		}
		return (amount * m_IncreaseRatio) - amount;
	}
}
