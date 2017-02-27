using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
	public Buildables type;
	PlacementHandler placementHandler;

	// Use this for initialization
	void Start()
	{
		placementHandler = FindObjectOfType<PlacementHandler>();
	}
	
	public void PlaceBuildable()
	{
		placementHandler.PlaceBuildable(type);
	}
}
