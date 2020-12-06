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

	public override void InitTree(XPTree tree)
	{
		base.InitTree(tree);
		tree.OnTreeChanged += UpdateTree;
		UpdateTree();
	}

	public override void UpdateTree()
	{
		base.UpdateTree();
		m_Background.sprite = m_Tree.Descriptor.Background;
		m_TreeTitle.text = m_Tree.Descriptor.TreeName;
	}
}