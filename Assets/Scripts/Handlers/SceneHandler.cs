using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
	public GameObject currentColony;
	public GameObject currentPlanet;

	List<Renderer> currentRenderers = new List<Renderer>();

	UIHandler uiHandler;

	// Use this for initialization
	void Start()
	{
		uiHandler = FindObjectOfType<UIHandler>();
	}

	public void ChangeColony(GameObject colony)
	{
		foreach (Renderer renderer in currentRenderers)
		{
			renderer.enabled = false;
		}

		currentColony = colony;
		currentRenderers.Clear();

		foreach (Renderer renderer in currentColony.GetComponent<Colony>().renderers)
		{
			renderer.enabled = true;
			currentRenderers.Add(renderer);
		}

		Renderer background = currentColony.GetComponentInParent<Planet>().colonyBackground.GetComponent<Renderer>();
		background.enabled = true;
		currentRenderers.Add(background);

		uiHandler.ChangeUIColony();
	}

	public void ChangePlanet(GameObject planet)
	{
		foreach (Renderer renderer in currentRenderers)
		{
			renderer.enabled = false;
		}

		currentPlanet = planet;
		currentRenderers.Clear();

		foreach (Renderer renderer in currentPlanet.GetComponent<Planet>().renderers)
		{
			renderer.enabled = true;
			currentRenderers.Add(renderer);
		}

		Renderer background = currentPlanet.GetComponent<Planet>().planetBackground.GetComponent<Renderer>();
		background.enabled = true;
		currentRenderers.Add(background);

		uiHandler.ChangeUIPlanet();
	}
}