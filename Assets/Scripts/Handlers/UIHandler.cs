using System.Collections;
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
	List<Vehicle> vehicles = new List<Vehicle>();

	public GameObject researchWindow;
	public GameObject researchBar;
	public GameObject popup;

	public ResourcesHandler resourcesHandler;
	ResearchHandler researchHandler;
	SceneHandler sceneHandler;
	Prefabs prefabs;

	float timePassed = 1;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
		prefabs = GetComponent<Prefabs>();
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
		UpdateVehicles();
	}

	// populates the vehicle panel on ui update
	public void UpdateVehicles()
	{
		foreach (Vehicle vehicle in sceneHandler.currentColony.GetComponentsInChildren<Vehicle>())
		{
			if (!vehicles.Contains(vehicle))
			{
				vehicles.Add(vehicle);
				GameObject vehicleButton = Instantiate(prefabs.vehicleButton);
				vehicleButton.GetComponent<VehicleButton>().vehicle = vehicle;
				vehicleButton.transform.SetParent(vehiclePanel.transform);
			}
		}
	}

	public void ClearVehicles()
	{
		foreach (Transform vehicle in vehiclePanel.transform)
		{
			Destroy(vehicle.gameObject);
		}

		vehicles.Clear();
	}

	public void DisplayVehicleDetails(Vehicle vehicle, Colony colony)
	{
		vehicleDetails.SetActive(true);
		vehicleDetails.GetComponent<VehicleDisplayer>().DisplayVehicleDetails(vehicle, colony);
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
