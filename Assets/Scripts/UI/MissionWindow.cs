using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWindow : MonoBehaviour, IInitializable
{
	Core core;
	SceneHandler sceneHandler;
	UIHandler UIHandler;
	public GameObject vehicle;

	public Dropdown missionTypesDropdown;
	public Dropdown destinationsDropdown;

	Dictionary<string, Colony> colonyRef = new Dictionary<string, Colony>();

	// Use this for initialization
	void Awake()
	{
		if (core == null)
		{
			core = FindObjectOfType<Core>();
			sceneHandler = core.GetComponent<SceneHandler>();
			UIHandler = core.GetComponent<UIHandler>();
		}

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnEnable()
	{
		PopulateMissionTypes();
		PopulateDestinations();
	}

	void OnDisable()
	{

	}

	public void CreateMission()
	{
		MissionTypes type = (MissionTypes) Enum.Parse(typeof(MissionTypes), missionTypesDropdown.captionText.text);

		switch (type)
		{
			case MissionTypes.Travel:
				Travel mission = new Travel(vehicle);
				mission.SetDestination(colonyRef[destinationsDropdown.captionText.text].transform);
				mission.SetTravelTime(3);
				mission.Init();
				UIHandler.UpdateUI();
				break;
			default:
				break;
		}
	}

	void PopulateMissionTypes()
	{
		missionTypesDropdown.ClearOptions();
		List<string> missionTypes = new List<string>(Enum.GetNames(typeof(MissionTypes)));
		missionTypesDropdown.AddOptions(missionTypes);
		missionTypesDropdown.captionText.text = missionTypesDropdown.options[0].text;
	}

	void PopulateDestinations()
	{
		destinationsDropdown.ClearOptions();
		destinationsDropdown.captionText.text = sceneHandler.currentColony.name;

		foreach (Colony colony in core.colonies)
		{
			destinationsDropdown.options.Add(new Dropdown.OptionData(colony.name));
			colonyRef.Add(colony.name, colony);
		}
	}

	public void DisplaySelect()
	{
		print(colonyRef[destinationsDropdown.captionText.text]);
	}

	public void Init()
	{

	}
}