using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissionTypes
{
	Travel
}

//TODO 2. finish mission handling
public class MissionHandler : MonoBehaviour, ITickable
{
	List<Mission> activeMissions = new List<Mission>();

	public Transform space;

	void Start()
	{
		Init();
	}

	public void AddMission(Mission mission)
	{
		activeMissions.Add(mission);
	}

	public void RemoveMission(Mission mission)
	{
		activeMissions.Remove(mission);
	}

	public void Init()
	{
		FindObjectOfType<Core>().tickables.Add(this);
	}

	public void Tick()
	{
		foreach (Mission mission in activeMissions)
		{
			mission.Tick();
		}
	}

}