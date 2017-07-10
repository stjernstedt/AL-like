using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	ResourcesHandler resourcesHandler;

	//TODO add spacecrafts to colony, display in ui, add load/unload functionality
	void Start()
	{
		resourcesHandler = GetComponent<ResourcesHandler>();
	}

	public void Load(Resources resourceType, int amount)
	{
		resourcesHandler.AddResource(resourceType, amount);
	}

	public void Unload(Resources resourceType, int amount)
	{
		resourcesHandler.RemoveResource(resourceType, amount);
	}

}
