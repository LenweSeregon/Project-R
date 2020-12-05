using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProgressionWrapper", menuName = "Progression/Wrapper")]
public class WrapperProgressionSystemUIComponent : ScriptableObject
{
	private Dictionary<ProgressionController, UIProgression> m_Progressions = new Dictionary<ProgressionController, UIProgression>();
	private Dictionary<XPTree, UITree> m_Trees = new Dictionary<XPTree, UITree>();
	private Dictionary<XPTreeTier, UITier> m_Tiers = new Dictionary<XPTreeTier, UITier>();
	private Dictionary<XPTreeElement, UITreeElement> m_Elements = new Dictionary<XPTreeElement, UITreeElement>();

	public void InitProgression(UIProgression uiProgression, ProgressionController progression)
	{
		uiProgression.InitProgression(progression);
		m_Progressions.Add(progression, uiProgression);
	}

	public void UpdateProgression(ProgressionController progression)
	{
		UIProgression uiProgression = m_Progressions[progression];
		uiProgression.UpdateProgression(progression);
	}

	public void InitTree(UITree uiTree, XPTree tree)
	{
		uiTree.UpdateTree(tree);
		m_Trees.Add(tree, uiTree);
		tree.OnTreeChanged += UpdateProgression;
	}

	public void UpdateTree(XPTree tree)
	{
		UITree uiTree = m_Trees[tree];
		uiTree.UpdateTree(tree);
	}

	public void InitTier(UITier uiTier, XPTreeTier tier)
	{
		uiTier.InitTier(tier);
		m_Tiers.Add(tier, uiTier);
	}

	public void UpdateTier(XPTreeTier tier)
	{
		UITier uiTier = m_Tiers[tier];
		uiTier.UpdateTier(tier);
	}

	public void InitElement(UITreeElement uiElement, XPTreeElement element, SkillProgressionDescriptor descriptor)
	{
		uiElement.InitElement(element);
		m_Elements.Add(element, uiElement);
		uiElement.UnlockButton.onClick.AddListener(delegate { ModifyElementLevel(element); } );
		element.OnLevelIncreased += UpdateElement;
		element.OnLevelDecreased += UpdateElement;
		element.OnLevelReset += UpdateElement;
	}

	public void UpdateElement(XPTreeElement element)
	{
		UITreeElement uiElement = m_Elements[element];
		uiElement.UpdateElement(element);
	}

	/*private void ModifyElementLevel(UITreeElement uiElement)
	{
		foreach (KeyValuePair<XPTreeElement, UITreeElement> pair in m_Elements)
		{
			if (pair.Value == uiElement)
			{
				XPTreeElement element = pair.Key;
				//Use new input system
				Debug.Log("Event Raised");
				if (Input.GetMouseButtonDown(0))
				{
					element.IncreaseLevel();
					Debug.Log("left click");
				}
				if (Input.GetMouseButtonDown(1))
				{
					Debug.Log("right click");
				}
				break;
			}
		}
	}*/

	private void ModifyElementLevel(XPTreeElement Element)
	{
		//Use new input system
		Debug.Log("Event Raised");
		if (Input.GetMouseButtonDown(0))
		{
			element.IncreaseLevel();
			Debug.Log("left click");
		}
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("right click");
		}
	}
}
