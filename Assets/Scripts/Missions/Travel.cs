using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : Mission
{
	float travelTime;
	float timeTraveled;
	Transform destination;

	//public GameObject subject;

	public Travel(GameObject subject) : base(subject)
	{

	}

	public override void Init()
	{
		missionHandler.AddMission(this);
		subject.transform.SetParent(missionHandler.space);
	}

	public override void OnComplete()
	{
		subject.transform.SetParent(destination);
		missionHandler.RemoveMission(this);
		//TODO update ui
	}

	public override void Tick()
	{
		timeTraveled += Time.deltaTime;
		if(timeTraveled > travelTime)
		{
			OnComplete();
		}
	}

	public void SetDestination(Transform dest)
	{
		destination = dest;
	}

	public void SetTravelTime(float time)
	{
		travelTime = time;
	}
}