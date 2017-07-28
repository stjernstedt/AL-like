using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColonyView : MonoBehaviour, IView
{
	public GameObject UIenergy;
	Text energyText;
	public GameObject UIore;
	Text oreText;

	public GameObject vehiclePanel;
	public GameObject vehicleDetails;
	List<Vehicle> vehicles = new List<Vehicle>();

	ResourcesHandler resourcesHandler;
	ResearchHandler researchHandler;
	SceneHandler sceneHandler;

	// Use this for initialization
	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();

		energyText = UIenergy.GetComponentInChildren<Text>();
		oreText = UIore.GetComponentInChildren<Text>();
	}

	public void StartView()
	{
		gameObject.SetActive(true);
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();
		ClearVehicles();
		UpdateView();
	}

	public void EndView()
	{
		gameObject.SetActive(false);
	}

	public void UpdateView()
	{
		energyText.text = "Energy: " + resourcesHandler.energy.amount;
		oreText.text = "Ore: " + resourcesHandler.ore.amount;
		UpdateVehicles();
	}

	// populates the vehicle panel on ui update
	void UpdateVehicles()
	{
		foreach (Vehicle vehicle in sceneHandler.currentColony.GetComponentsInChildren<Vehicle>())
		{
			if (!vehicles.Contains(vehicle))
			{
				vehicles.Add(vehicle);
				GameObject vehicleButton = Instantiate(Prefabs.Instance.vehicleButton);
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
}