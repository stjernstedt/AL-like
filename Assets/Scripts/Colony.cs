using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour, ITickable
{
	ResourcesHandler resourceHandler;
	public List<Renderer> renderers = new List<Renderer>();

	// Use this for initialization
	void Start()
	{
		transform.parent.GetComponent<Planet>().renderers.Add(GetComponent<Renderer>());
		renderers.Add(transform.parent.GetComponent<Planet>().colonyBackground.GetComponent<Renderer>());
		Init();
	}

	public void Init()
	{
		resourceHandler = GetComponent<ResourcesHandler>();
		resourceHandler.AddResource(Resources.Ore, 20);

		Core core = FindObjectOfType<Core>();
		core.tickables.Add(this);
		core.colonies.Add(this);
	}

	public void Tick()
	{

	}

}