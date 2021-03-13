namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class XPTreeTier : AbstractXPComponent
	{
		private List<XPTreeElement> m_Elements = new List<XPTreeElement>();
		private XPTree m_Tree;

		public List<XPTreeElement> Elements => m_Elements;
		public XPTree Tree => m_Tree;

		public XPTreeTier(XPTreeTierDescriptor descriptor, XPTree tree)
		{
			foreach(XPTreeElementDescriptor elementDescriptor in descriptor.Elements)
			{
				m_Elements.Add(new XPTreeElement(elementDescriptor, this));
			}
			m_Tree = tree;
		}

		public void NotifyUnlockElement(XPTreeElement element)
		{
			m_Tree.NotifyUnlockElement(element);
		}
	}
}
