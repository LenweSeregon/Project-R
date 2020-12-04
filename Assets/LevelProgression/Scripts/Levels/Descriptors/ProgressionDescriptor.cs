namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityAtoms.BaseAtoms;

	[CreateAssetMenu(fileName = "ProgressionDescriptor", menuName = "Progression/Descriptors/PlainProgressionDescriptor")]
	public class ProgressionDescriptor : ScriptableObject, System.ICloneable
	{
		[SerializeField] protected FloatVariable m_BaseXP;
		[SerializeField] protected IntVariable m_MaxLevel;
		[SerializeField] protected float m_IncreaseRatio;
		[SerializeField] protected string m_DescriptorName;
		[SerializeField] protected XPType m_XPType;

		public FloatVariable BaseXP => m_BaseXP;
		public IntVariable MaxLevel => m_MaxLevel;
		public string Name => m_DescriptorName;
		public XPType Type => m_XPType;

		public ProgressionDescriptor(ProgressionDescriptor descriptor)
		{
			m_BaseXP = descriptor.BaseXP;
			m_MaxLevel = descriptor.MaxLevel;
			m_DescriptorName = descriptor.Name;
			m_XPType = descriptor.Type;
		}

		public float FindNextThreshold(int level)
		{
			float amount = m_BaseXP.Value;
			for (int i = 2; i <= level; ++i)
			{
				amount *= m_IncreaseRatio;
			}
			return (amount * m_IncreaseRatio) - amount;
		}

		public virtual ProgressionController CreateController()
		{
			return new ProgressionController(this);
		}

		public object Clone()
		{
			return (ProgressionDescriptor) Instantiate(this);
		}
	}

}