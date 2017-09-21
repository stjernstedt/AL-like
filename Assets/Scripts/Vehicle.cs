using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	public ResourcesHandler resourcesHandler;

	void Start()
	{
		resourcesHandler = GetComponent<ResourcesHandler>();
		Load(Resources.Energy, 100);
	}

	public void Load(Resources resourceType, int amount)
	{
		resourcesHandler.AddResource(resourceType, amount);
	}

	public void Unload(Resources resourceType, int amount)
	{
		resourcesHandler.RemoveResource(resourceType, amount);
	}

	//TODO add movement between planets/colonies
	public void Travel(GameObject destination)
	{
		transform.SetParent(destination.transform);
	}
}
