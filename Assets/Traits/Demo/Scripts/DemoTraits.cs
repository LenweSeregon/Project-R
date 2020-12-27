using com.CompanyR.FrameworkR.TraitSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoTraits : MonoBehaviour
{
	[Header("Traits Entities")]
	[SerializeField] private TraitsHandler m_TraitsHandler;
	[SerializeField] private TraitDescriptor m_TraitToAdd;
	private TraitsController m_SelectedController = null;

	[Space(20)]
	[Header("UI Elements")]
	[SerializeField] private TMP_InputField m_ControllerInputField;
	[SerializeField] private TMP_InputField m_TraitInputField;
	[SerializeField] private TextMeshProUGUI m_SelectedControllerText;

	[Space(20)]
	[Header("Containers")]
	[SerializeField] private GameObject m_Controllers;

	[Space(20)]
	[Header("Prefabs")]
	[SerializeField] private GameObject m_ControllerPrefab;
	[SerializeField] private TextMeshProUGUI m_TraitText;
	[SerializeField] private TextMeshProUGUI m_ComboText;
	[SerializeField] private TextMeshProUGUI m_EffectText;

	public void AddController()
	{
		TraitsController controller = GameObject.Instantiate(m_ControllerPrefab, m_Controllers.transform).GetComponent<TraitsController>();
		controller.InitControllerName(m_ControllerInputField.text);
		m_TraitsHandler?.AddController(controller);
		m_SelectedController = controller;
		m_SelectedControllerText.text = controller.ControllerName;

		DemoTraitController demoTraitController = controller.GetComponent<DemoTraitController>();
		demoTraitController.InitName(controller.ControllerName);

		UpdateInfo();
	}

	public void RemoveController()
	{
		if (m_SelectedController != null)
		{
			Destroy(m_SelectedController.gameObject);
			m_SelectedController = null;
			m_SelectedControllerText.text = "";
			UpdateInfo();
		}
	}

	[ContextMenu("AddTrait")]
	public void AddTrait()
	{
		m_SelectedController?.AddTrait(m_TraitToAdd);
		UpdateInfo();
	}

	public void RemoveTrait()
	{
		TraitInstance trait = m_SelectedController?.GetTrait(m_TraitInputField.text);
		m_SelectedController?.RemoveTrait(trait.Descriptor);
		UpdateInfo();
	}

	public void SwitchController(TraitsController controller)
	{
		m_SelectedController = null;
		UpdateInfo();
		m_SelectedController = controller;
		UpdateInfo();
	}

	private void UpdateInfo()
	{
		if(m_SelectedController == null)
		{
			m_SelectedControllerText.text = "";
			m_TraitText.text = "";
			m_ComboText.text = "";
			m_EffectText.text = "";
		}
		else
		{
			m_SelectedControllerText.text = m_SelectedController.ControllerName;
			foreach (TraitInstance trait in m_SelectedController.Traits)
			{
				m_TraitText.text += trait.Descriptor.IDName + "\n";
			}
			foreach (TraitDescriptor combo in m_SelectedController.Combo)
			{
				m_ComboText.text += combo.IDName + "\n";
			}
		}
	}
}
