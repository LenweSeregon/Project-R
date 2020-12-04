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
		public Transform TiersContainer => m_TiersContainer;

		public void InitTree(XPTree tree)
		{
			UpdateTree(tree);
		}

		public void UpdateTree(XPTree tree)
		{
			m_Background.sprite = tree.Descriptor.Background;
			m_TreeTitle.text = tree.Descriptor.TreeName;
		}
	}
}