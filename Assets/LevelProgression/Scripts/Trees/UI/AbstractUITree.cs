namespace com.CompanyR.FrameworkR.ProgressSystem
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AbstractUITree : MonoBehaviour
	{
		protected XPTree m_Tree;

		public virtual void InitTree(XPTree tree)
		{
			m_Tree = tree;
		}

		public virtual void UpdateTree()
		{

		}
	}
}
