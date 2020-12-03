using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrapperProgressionSystemUIComponent
{
	public static void InitLevel(UILevel uiLevel, LevelController controller)
	{
		uiLevel.TitleText.text = controller.Descriptor.Type.Value;
	}

	public static void UpdateLevel(UILevel uiLevel, LevelController controller)
	{
		uiLevel.UpdateLevel(controller);
		controller.Level = uiLevel;
	}

	public static void InitTree(UITree uiTree, XPTree tree)
	{
		uiTree.Background.sprite = tree.Descriptor.Background;
		uiTree.Title.text = tree.Descriptor.TreeName;
	}

	public static void InitTier(UITier uiTier, XPTreeTier tier)
	{

	}

	public static void InitElement(UIElement uiElement, XPTreeElement element, SkillLevelDescriptor descriptor)
	{
		uiElement.Background.sprite = element.Descriptor.SkillSprite;
		if (element.Level > 0)
		{
			uiElement.Overlay.sprite = descriptor.UnlockedSprite;
			if (element.Descriptor.MaxLevel > 1)
			{
				uiElement.SkillLevelText.text = string.Format("{0}/{1}", element.Level, element.Descriptor.MaxLevel);
			}
			else
			{
				uiElement.SkillLevelText.text = "";
			}
		}
		else
		{
			uiElement.Overlay.sprite = descriptor.LockedSprite;
		}
		if (element.Element == null)
		{
			uiElement.UnlockButton.onClick.AddListener(() => element.OnActionReceived(descriptor));
			element.Element = uiElement;
		}
	}
}
