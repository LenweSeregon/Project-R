using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITree : AbstractUITree
{
	[SerializeField] private Image m_Background;
	[SerializeField] private TextMeshProUGUI m_TreeTitle;
	[SerializeField] private Transform m_TiersContainer;
	public Transform TiersContainer => m_TiersContainer;

	public override void InitElement(XPTree tree)
	{
		base.InitElement(tree);
		tree.OnTreeChanged += UpdateElement;
		UpdateElement();
	}

	public override void UpdateElement()
	{
		base.UpdateElement();
		m_Background.sprite = m_Tree.Descriptor.Background;
		m_TreeTitle.text = m_Tree.Descriptor.TreeName;
	}
}