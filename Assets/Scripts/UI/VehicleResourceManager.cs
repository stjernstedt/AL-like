using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleResourceManager : MonoBehaviour
{
	public GameObject vehicleResourcesTextPanel;
	public GameObject colonyResourcesTextPanel;
	public GameObject vehicleSlidersPanel;
	public GameObject colonySlidersPanel;

	List<Resource> resourceTypes = new List<Resource>();
	List<ResourceTextSetter> vehicleResources = new List<ResourceTextSetter>();
	List<ResourceTextSetter> colonyResources = new List<ResourceTextSetter>();

	Vehicle vehicle;
	Colony colony;

	public bool updating = false;

	public void DisplayVehicleDetails(Vehicle vehicleToDisplay, Colony colonyToDisplay)
	{
		updating = true;
		ClearPanels();

		vehicle = vehicleToDisplay;
		colony = colonyToDisplay;

		resourceTypes = colony.GetComponent<ResourcesHandler>().GetResourceTypes();

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

		PopulateResources();
		RefreshResources();
		updating = false;
	}

	void PopulateResources()
	{
		// populates the vehicle and colony resource list
		foreach (Resource resourceType in resourceTypes)
		{
			// for vehicle
			GameObject resourceText = Instantiate(Prefabs.Instance.resourceText);
			Resource resource = (Resource)vehicle.GetComponent(resourceType.GetType());
			resourceText.transform.SetParent(vehicleResourcesTextPanel.transform);
			GameObject sliderGO = Instantiate(Prefabs.Instance.vehicleResourceSlider);
			//Slider slider = sliderGO.GetComponentInChildren<Slider>();
			sliderGO.transform.SetParent(vehicleSlidersPanel.transform);
			resourceText.GetComponent<ResourceTextSetter>().SetResource(resource, sliderGO);
			vehicleResources.Add(resourceText.GetComponent<ResourceTextSetter>());

			// for colony
			resourceText = Instantiate(Prefabs.Instance.resourceText);
			resource = (Resource)colony.GetComponent(resourceType.GetType());
			resourceText.transform.SetParent(colonyResourcesTextPanel.transform);
			sliderGO = Instantiate(Prefabs.Instance.colonyResourceSlider);
			//slider = sliderGO.GetComponentInChildren<Slider>();
			sliderGO.transform.SetParent(colonySlidersPanel.transform);
			resourceText.GetComponent<ResourceTextSetter>().SetResource(resource, sliderGO);
			colonyResources.Add(resourceText.GetComponent<ResourceTextSetter>());
		}
	}

	void ClearPanels()
	{
		foreach (Transform resource in vehicleResourcesTextPanel.transform)
		{
			Destroy(resource.gameObject);
		}
		foreach (Transform resource in colonyResourcesTextPanel.transform)
		{
			Destroy(resource.gameObject);
		}

		foreach (Transform resource in vehicleSlidersPanel.transform)
		{
			Destroy(resource.gameObject);
		}

		foreach (Transform resource in colonySlidersPanel.transform)
		{
			Destroy(resource.gameObject);
		}

	}

	public void RefreshResources()
	{
		foreach (ResourceTextSetter setter in vehicleResources)
		{
			setter.UpdateResource();
		}

		foreach (ResourceTextSetter setter in colonyResources)
		{
			setter.UpdateResource();
		}


	}

	public void TransferResources()
	{
		foreach (ResourceTextSetter resource in vehicleResources)
		{
			Resources resourceType = resource.GetResource().type;
			InputField field = resource.sliderPair.GetComponentInChildren<InputField>();
			int amount;
			int.TryParse(field.text, out amount);

			if (colony.GetComponent<ResourcesHandler>().AddResource(resourceType, amount))
			{
				vehicle.GetComponent<ResourcesHandler>().RemoveResource(resourceType, amount);
			}
		}

		foreach (ResourceTextSetter resource in colonyResources)
		{
			Resources resourceType = resource.GetResource().type;
			InputField field = resource.sliderPair.GetComponentInChildren<InputField>();
			int amount;
			int.TryParse(field.text, out amount);

			if (vehicle.GetComponent<ResourcesHandler>().AddResource(resourceType, amount))
			{
				colony.GetComponent<ResourcesHandler>().RemoveResource(resourceType, amount);
			}
		}


		RefreshResources();
	}
}