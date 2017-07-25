using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO design planet ui and general toolbar for all views
public class Planet : MonoBehaviour
{
	public GameObject planetBackground;
	public GameObject colonyBackground;
	public List<Renderer> renderers = new List<Renderer>();

	// Use this for initialization
	void Start()
	{
		renderers.Add(planetBackground.GetComponent<Renderer>());
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}