using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleDisplayer : MonoBehaviour
{
	public GameObject resourcesPanel;
	public Slider resourceSlider;

	List<Resource> resourceTypes = new List<Resource>();
	SceneHandler sceneHandler;
	Prefabs prefabs;

	// Use this for initialization
	void Awake()
	{
		prefabs = FindObjectOfType<Prefabs>();
		sceneHandler = FindObjectOfType<SceneHandler>();
	}

	public void DisplayVehicleDetails(Vehicle vehicle)
	{
		resourceSlider.maxValue = vehicle.resourcesHandler.capacity;
		foreach (Transform resource in resourcesPanel.transform)
		{
			Destroy(resource.gameObject);
		}

		resourceTypes = sceneHandler.currentColony.GetComponent<ResourcesHandler>().GetResourceTypes();

		foreach (Resource resourceType in vehicle.GetComponent<ResourcesHandler>().GetResourceTypes())
		{
			bool containsType = false;
			foreach (Resource resourceInList in resourceTypes)
			{
				if (resourceInList.type == resourceType.type)
				{
					containsType = true;
				}
			}
			if (!containsType)
			{
				resourceTypes.Add(resourceType);
			}
		}

		foreach (Resource resourceType in resourceTypes)
		{
			GameObject resourceButton = Instantiate(prefabs.resourceButton);
			resourceButton.transform.SetParent(resourcesPanel.transform);
			resourceButton.GetComponentInChildren<Text>().text = resourceType.resourceName;
		}

	}

}