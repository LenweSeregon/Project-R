namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	[CreateAssetMenu(fileName = "SkillLevelDescriptor", menuName = "Level/Descriptors/SkillLevelDescriptor")]
	public class SkillLevelDescriptor : LevelDescriptor
	{
		[SerializeField] protected List<XPTreeDescriptor> m_Trees = new List<XPTreeDescriptor>();
		[SerializeField] protected Sprite m_LockedSprite;
		[SerializeField] protected Sprite m_UnlockedSprite;

		public Sprite LockedSprite => m_LockedSprite;
		public Sprite UnlockedSprite => m_UnlockedSprite;

		public List<XPTreeDescriptor> Trees => m_Trees;

		public SkillLevelDescriptor(SkillLevelDescriptor descriptor) : base(descriptor)
		{
			m_Trees = descriptor.Trees;
		}

		public override LevelController CreateController()
		{
			return new SkillLevelController(this);
		}
	}

}