﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleButton : MonoBehaviour
{
	public Vehicle vehicle;

	UIHandler uiHandler;

	void Awake()
	{
		uiHandler = FindObjectOfType<UIHandler>();
	}

	public void ActivateButton()
	{
		uiHandler.DisplayMissionWindow(vehicle, vehicle.GetComponentInParent<Colony>());
	}
}
