using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour, ITickable
{
	public Resources resourceType;
	public float powerUsed;
	public float amountProduced;
	public float frequency;

	float timeLapsed = 0;
	ResourcesHandler resourceHandler;
	ResearchHandler researchHandler;

	// Use this for initialization
	void Start()
	{
		Init();
		resourceHandler = transform.parent.GetComponent<ResourcesHandler>();
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	public void Init()
	{
		FindObjectOfType<Core>().tickables.Add(this);
	}

	public void Tick()
	{
		timeLapsed += Time.deltaTime;
		if (timeLapsed > frequency)
		{
			if (resourceHandler.UseResource(Resources.Energy, powerUsed))
			{
				if (resourceType == Resources.Research)
				{
					researchHandler.GenerateResearch(amountProduced);
				}
				else
				{
					resourceHandler.GenerateResource(resourceType, amountProduced);
				}
			}
			timeLapsed = 0;
		}
	}
}