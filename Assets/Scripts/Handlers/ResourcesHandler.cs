using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesHandler : MonoBehaviour
{
	public Energy energy;
	public Ore ore;
	
	void Start()
	{
		energy = gameObject.AddComponent<Energy>();
		ore = gameObject.AddComponent<Ore>();
		energy.amount = 0;
		ore.amount = 20;
	}


	public void GenerateResource(Resources resourceType, float amount)
	{
		
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

	public bool UseResource(Resources resourceType, float amount)
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

}