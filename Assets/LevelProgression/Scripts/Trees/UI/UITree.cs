namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UITree : MonoBehaviour
	{
		[SerializeField] private Image m_Background;
		[SerializeField] private TextMeshProUGUI m_TreeTitle;
		[SerializeField] private Transform m_TiersContainer;

		public Image Background => m_Background;
		public TextMeshProUGUI Title => m_TreeTitle;
		public Transform TiersContainer => m_TiersContainer;
	}
}