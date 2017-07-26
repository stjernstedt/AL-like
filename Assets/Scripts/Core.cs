using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	public List<ITickable> tickables = new List<ITickable>();
	public GameObject startingColony;

	// Use this for initialization
	void Start()
	{
		GetComponent<SceneHandler>().ChangeColony(startingColony);
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
