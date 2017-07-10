using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleDisplayer : MonoBehaviour
{
	public GameObject vehicleResourcesPanel;
	public GameObject otherResourcesPanel;
	Prefabs prefabs;

	// Use this for initialization
	void Awake()
	{
		prefabs = FindObjectOfType<Prefabs>();
	}

	public void DisplayVehicleDetails(Vehicle vehicle)
	{
		foreach (Resource resource in vehicle.GetComponents<Resource>())
		{
			GameObject resourceButton = Instantiate(prefabs.resourceButton);
			resourceButton.transform.SetParent(vehicleResourcesPanel.transform);
			resourceButton.GetComponentInChildren<Text>().text = resource.resourceName;
		}
	}

}