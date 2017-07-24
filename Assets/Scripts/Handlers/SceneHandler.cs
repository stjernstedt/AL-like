using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
	public GameObject currentColony;
	public GameObject currentPlanet;

	UIHandler uiHandler;

	// Use this for initialization
	void Start()
	{
		uiHandler = FindObjectOfType<UIHandler>();
	}

	public void ChangeColony(GameObject colony)
	{
		SpriteRenderer[] spriteRenderers = currentColony.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer renderer in spriteRenderers)
		{
			renderer.enabled = false;
		}

		currentColony = colony;
		spriteRenderers = currentColony.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer renderer in spriteRenderers)
		{
			renderer.enabled = true;
		}

		uiHandler.resourcesHandler = currentColony.GetComponent<ResourcesHandler>();
		uiHandler.ClearVehicles();
		uiHandler.UpdateUI();
	}

	public void ChangePlanet(GameObject planet)
	{
		//TODO work out how to change scenes
		//GameObject[] colonyView = GameObject.FindGameObjectsWithTag(Tags.colonyView);
		//foreach (GameObject item in colonyView)
		//{
		//	item.GetComponent<Renderer>().enabled = false;
		//}

		Renderer[] renderers = GetComponents<Renderer>();
		foreach (Renderer renderer in renderers)
		{
			renderer.enabled = false;
		}
	}
}