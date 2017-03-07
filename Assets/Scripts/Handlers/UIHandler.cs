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
	public GameObject researchBar;
	public GameObject popup;

	ResourcesHandler resourcesHandler;
	ResearchHandler researchHandler;
	SceneHandler sceneHandler;

	float timePassed = 1;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();
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
		energy.GetComponentInChildren<Text>().text = "Energy: " + resourcesHandler.energy.amount;
		ore.GetComponentInChildren<Text>().text = "Ore: " + resourcesHandler.ore.amount;
		//TODO tweak the way researchprogress is displayed/stored
		researchBar.GetComponent<Image>().fillAmount = researchHandler.researchProgress;
		//TODO reset progress when changing tech
		researchBar.GetComponentInChildren<Text>().text = (researchHandler.researchProgress * 100) + "%";
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
