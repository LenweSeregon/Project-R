using com.CompanyR.FrameworkR.TraitSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoTraitController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI m_ControllerName;

	private void OnMouseDown()
	{
		DemoTraits demo = GameObject.Find("DemoTraits").GetComponent<DemoTraits>();
		demo.SwitchController(GetComponent<TraitsController>());
	}

	public void InitName(string name)
	{
		m_ControllerName.text = name;
	}
}
