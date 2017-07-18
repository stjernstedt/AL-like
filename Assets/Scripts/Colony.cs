using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour, ITickable
{
	ResourcesHandler resourceHandler;

	// Use this for initialization
	void Start()
	{
		Init();
	}

	public void Init()
	{
		resourceHandler = GetComponent<ResourcesHandler>();
		resourceHandler.AddResource(Resources.Ore, 20);
		FindObjectOfType<Core>().tickables.Add(this);
	}

	public void Tick()
	{

	}

}