namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UITreeElement : MonoBehaviour
	{
		[SerializeField] private Image m_Background;
		[SerializeField] private Image m_Overlay;
		[SerializeField] private TextMeshProUGUI m_SkillLevelText;
		[SerializeField] private Button m_UnlockButton;
		private SkillProgressionDescriptor m_Descriptor;

		public Image Background => m_Background;
		public Image Overlay => m_Overlay;
		public TextMeshProUGUI SkillLevelText => m_SkillLevelText;
		public Button UnlockButton => m_UnlockButton;

		public void InitElement(XPTreeElement element)
		{
			m_Background.sprite = element.Descriptor.SkillSprite;
			m_Descriptor = (SkillProgressionDescriptor) element.Tier.Tree.Controller.Descriptor;
			UpdateElement(element);
			//element.OnUnlock += Update
		}

		public void UpdateElement(XPTreeElement element)
		{
			if (element.Level > 0)
			{
				m_Overlay.sprite = m_Descriptor.UnlockedSprite;
				if (element.Descriptor.MaxLevel > 1)
				{
					m_SkillLevelText.text = string.Format("{0}/{1}", element.Level, element.Descriptor.MaxLevel);
				}
				else
				{
					m_SkillLevelText.text = "";
				}
			}
			else
			{
				m_Overlay.sprite = m_Descriptor.LockedSprite;
			}
		}
	}
}
