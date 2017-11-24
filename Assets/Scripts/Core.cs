using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	public List<ITickable> tickables = new List<ITickable>();
	public GameObject startingColony;

	public List<Colony> colonies = new List<Colony>();
	public List<Colony> spaceStations = new List<Colony>();
	public List<Planet> planets = new List<Planet>();


	// Use this for initialization
	void Start()
	{
		GetComponent<SceneHandler>().ChangeColony(startingColony);
		//TODO 1. rework class system, register tickables and initialables, make base class?
	}
	
	// Update is called once per frame
	void Update()
	{
		foreach (ITickable tickable in tickables)
		{
			tickable.Tick();
		}
	}
}
