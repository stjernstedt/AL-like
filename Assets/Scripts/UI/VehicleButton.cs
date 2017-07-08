using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleButton : MonoBehaviour
{
	public GameObject vehicle;

	SceneHandler sceneHandler;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
	}

	public void ActivateButton()
	{
		sceneHandler.DisplayVehicleScreen(vehicle);
	}
}
