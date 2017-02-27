using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
	public int power;
	public int ore;

	public Dictionary<Resources, int> resourcesNeeded = new Dictionary<Resources, int>();

	// Use this for initialization
	void Awake()
	{
		resourcesNeeded.Add(Resources.Energy, power);
		resourcesNeeded.Add(Resources.Ore, ore);
	}

}
