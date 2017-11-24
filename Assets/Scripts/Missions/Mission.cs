using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : ITickable
{
	public bool running = false;
	public GameObject subject;
	
	protected MissionHandler missionHandler;

	public Mission(GameObject subject)
	{
		missionHandler = Object.FindObjectOfType<MissionHandler>();
		this.subject = subject;
	}

	public Mission()
	{
		missionHandler = Object.FindObjectOfType<MissionHandler>();
	}

	public abstract void Init();
	public abstract void Tick();
	public abstract void OnComplete();
}