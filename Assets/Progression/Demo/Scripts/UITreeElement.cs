using com.CompanyR.FrameworkR.ProgressSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITreeElement : AbstractUITreeElement
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

	public override void InitElement(XPTreeElement element)
	{
		base.InitElement(element);
		m_Background.sprite = element.Descriptor.SkillSprite;
		m_Descriptor = (SkillProgressionDescriptor)element.Tier.Tree.Controller.Descriptor;
		m_UnlockButton.onClick.AddListener(ModifyElementLevel);
		m_Element.OnLevelIncreased += UpdateElement;
		m_Element.OnLevelDecreased += UpdateElement;
		UpdateElement();
		//element.OnUnlock += Update
	}

	public override void UpdateElement()
	{
		base.UpdateElement();
		if (m_Element.Level > 0)
		{
			m_Overlay.sprite = m_Descriptor.UnlockedSprite;
			if (m_Element.Descriptor.MaxLevel > 1)
			{
				m_SkillLevelText.text = string.Format("{0}/{1}", m_Element.Level, m_Element.Descriptor.MaxLevel);
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

	private void ModifyElementLevel()
	{
		Debug.Log("Increasing level");
		m_Element.IncreaseLevel();
		//Use new input system
		/*if (Input.GetMouseButtonDown(0))
		{
			m_Element.IncreaseLevel();
			Debug.Log("left click");
		}
		if (Input.GetMouseButtonDown(1))
		{
			m_Element.DecreaseLevel();
			Debug.Log("right click");
		}*/
	}
}