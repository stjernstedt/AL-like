using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
	public GameObject planetView;
	public GameObject colonyView;

	public GameObject missionWindow;

	public GameObject researchWindow;
	public GameObject researchBar;
	public GameObject popup;

	IView currentView;

	float timePassed = 1;

	void Awake()
	{

	}

	void Update()
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			UpdateUI();
			timePassed = 0;
		}
	}

	public void UpdateUI()
	{
		currentView.UpdateView();
	}

	public void ChangeUIColony()
	{
		if (currentView != null)
			currentView.EndView();
		currentView = colonyView.GetComponent<IView>();
		currentView.StartView();
	}

	public void ChangeUIPlanet()
	{
		if (currentView != null)
			currentView.EndView();
		currentView = planetView.GetComponent<IView>();
		currentView.StartView();
	}

	public void DisplayMissionWindow(Vehicle vehicle, Colony colony)
	{
		//BUG if spamming vehicle button you get missingreference exception
		missionWindow.SetActive(true);
		if (!missionWindow.GetComponent<VehicleResourceManager>().updating)
		{
			missionWindow.GetComponent<MissionWindow>().vehicle = vehicle.gameObject;
			missionWindow.GetComponent<VehicleResourceManager>().DisplayVehicleDetails(vehicle, colony);
		}
	}

	public void ToggleResearchWindow()
	{
		researchWindow.SetActive(!researchWindow.activeSelf);
	}

	public void ShowPopup()
	{
		popup.SetActive(true);
	}
}
