using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// placed on all objects with an inventory
//TODO split inventory to own class and keep resourcehandlers on colonies?
public class ResourcesHandler : MonoBehaviour
{
	public int capacity;
	public Energy energy;
	public Ore ore;
	
	void Awake()
	{
		energy = gameObject.AddComponent<Energy>();
		ore = gameObject.AddComponent<Ore>();
		energy.amount = 0;
		ore.amount = 20;
	}


	public void AddResource(Resources resourceType, float amount)
	{
		//TODO add capacity check, return bool
		switch (resourceType)
		{
			case Resources.Energy:
				energy.amount += amount;
				break;
			case Resources.Ore:
				ore.amount += amount;
				break;
			default:
				break;
		}

	}

	public bool RemoveResource(Resources resourceType, float amount)
	{
		if (amount == 0) return true;

		switch (resourceType)
		{
			case Resources.Energy:
				if (energy.amount >= amount)
				{
					energy.amount -= amount;
					return true;
				}
				break;
			case Resources.Ore:
				if (ore.amount >= amount)
				{
					ore.amount -= amount;
					return true;
				}
				break;
			default:
				break;
		}
		return false;
	}

	public List<Resource> GetResourceTypes()
	{
		List<Resource> resources = new List<Resource>();
		foreach (Resource resource in GetComponents<Resource>())
		{
			resources.Add(resource);
		}

		return resources;
	}
}