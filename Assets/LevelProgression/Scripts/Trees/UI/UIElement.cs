namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIElement : MonoBehaviour
	{
		[SerializeField] private Image m_Background;
		[SerializeField] private Image m_Overlay;
		[SerializeField] private TextMeshProUGUI m_SkillLevelText;
		[SerializeField] private Button m_UnlockButton;

		public Image Background => m_Background;
		public Image Overlay => m_Overlay;
		public TextMeshProUGUI SkillLevelText => m_SkillLevelText;
		public Button UnlockButton => m_UnlockButton;
	}
}
