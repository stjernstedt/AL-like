using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
	public List<ITickable> tickables = new List<ITickable>();

	// Use this for initialization
	void Start()
	{

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
