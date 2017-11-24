using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO design planet ui and general toolbar for all views
public class Planet : MonoBehaviour, ITickable
{
	public GameObject planetBackground;
	public GameObject colonyBackground;
	public List<Renderer> renderers = new List<Renderer>();

	void Start()
	{
		renderers.Add(planetBackground.GetComponent<Renderer>());
		Init();
	}

	public void Init()
	{
		Core core = FindObjectOfType<Core>();
		core.tickables.Add(this);
		core.planets.Add(this);
	}

	public void Tick()
	{

	}
}