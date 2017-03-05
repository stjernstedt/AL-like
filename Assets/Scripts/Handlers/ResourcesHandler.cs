using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesHandler : MonoBehaviour
{
	public float energy
	{
		get;
		private set;
	}
	public float ore
	{
		get;
		private set;
	}

	void Start()
	{
		energy = 0;
		ore = 20;
	}


	public void GenerateResource(Resources resourceType, float amount)
	{
		switch (resourceType)
		{
			case Resources.Energy:
				energy += amount;
				break;
			case Resources.Ore:
				ore += amount;
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
				if (energy >= amount)
				{
					energy -= amount;
					return true;
				}
				break;
			case Resources.Ore:
				if (ore >= amount)
				{
					ore -= amount;
					return true;
				}
				break;
			default:
				break;
		}
		return false;
	}

}