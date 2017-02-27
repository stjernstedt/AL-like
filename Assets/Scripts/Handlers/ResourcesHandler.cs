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

	UIHandler uiHandler;

	void Start()
	{
		uiHandler = FindObjectOfType<UIHandler>();
		energy = 0;
		ore = 20;
		uiHandler.UpdateUI();
	}


	public void GenerateResource(Resources resourceType, float amount)
	{
		switch (resourceType)
		{
			case Resources.Energy:
				energy += amount;
				uiHandler.UpdateUI();
				break;
			case Resources.Ore:
				ore += amount;
				uiHandler.UpdateUI();
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
					uiHandler.UpdateUI();
					return true;
				}
				break;
			case Resources.Ore:
				if (ore >= amount)
				{
					ore -= amount;
					uiHandler.UpdateUI();
					return true;
				}
				break;
			default:
				break;
		}
		return false;
	}

}