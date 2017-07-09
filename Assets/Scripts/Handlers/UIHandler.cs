﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public GameObject UIenergy;
	Text energyText;
	public GameObject UIore;
	Text oreText;
	//public GameObject UIresearch;
	//Text researchText;

	public GameObject vehiclePanel;
	public GameObject vehicleDetails;

	public GameObject researchWindow;
	public GameObject researchBar;
	public GameObject popup;

	public ResourcesHandler resourcesHandler;
	ResearchHandler researchHandler;
	SceneHandler sceneHandler;

	float timePassed = 1;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();
		energyText = UIenergy.GetComponentInChildren<Text>();
		oreText = UIore.GetComponentInChildren<Text>();
		//researchText = UIresearch.GetComponentInChildren<Text>();
	}

	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			UpdateUI();
			timePassed = 0;
		}
	}

	public void UpdateUI()
	{
		energyText.text = "Energy: " + resourcesHandler.energy.amount;
		oreText.text = "Ore: " + resourcesHandler.ore.amount;
		//TODO tweak the way researchprogress is displayed/stored
		researchBar.GetComponent<Image>().fillAmount = researchHandler.researchProgress;
		//TODO reset progress when changing tech
		researchBar.GetComponentInChildren<Text>().text = (researchHandler.researchProgress * 100) + "%";
	}

	public void UpdateVehicles()
	{
		foreach (Vehicle spacecraft in sceneHandler.currentColony.GetComponents<Vehicle>())
		{
			//TODO add buttons
		}
	}

	public void ShowVehicleDetails()
	{
		vehicleDetails.SetActive(true);
	}

	public void ToggleResearchWindow()
	{
		researchWindow.SetActive(!researchWindow.activeSelf);
	}

	public void ShowPopup()
	{
		popup.SetActive(true);
	}
}
