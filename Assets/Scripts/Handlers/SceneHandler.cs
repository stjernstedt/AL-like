using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
	public GameObject currentColony;

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

		uiHandler.UpdateUI();
	}

	public void DisplayVehicleScreen(GameObject vehicle)
	{

	}
}