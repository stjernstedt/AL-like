using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public GameObject energy;
	public GameObject ore;
	public GameObject research;

	public GameObject researchWindow;

	ResourcesHandler resourcesHandler;
	ResearchHandler researchHandler;
	SceneHandler sceneHandler;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	public void UpdateUI()
	{
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();
		energy.GetComponentInChildren<Text>().text = "Energy: " + resourcesHandler.energy;
		ore.GetComponentInChildren<Text>().text = "Ore: " + resourcesHandler.ore;
		research.GetComponentInChildren<Text>().text = "Research: " + researchHandler.researchPoints;
	}

	public void ToggleResearchWindow()
	{
		researchWindow.SetActive(!researchWindow.activeSelf);
	}
}
