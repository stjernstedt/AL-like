using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchHandler : MonoBehaviour
{
	public GameObject research;

	ResearchItem currentResearch;

	List<ResearchItem> lockedResearch = new List<ResearchItem>();
	List<ResearchItem> unlockedResearch = new List<ResearchItem>();
	List<ResearchItem> doneResearch = new List<ResearchItem>();

	public float researchPoints
	{
		get; private set;
	}

	// Use this for initialization
	public void Start()
	{
		lockedResearch.Add(research.GetComponent<Quarry>());
		unlockedResearch.Add(research.GetComponent<FusionPower>());
	}

	public void GenerateResearch(float amount)
	{
		//researchPoints += amount;
		if (currentResearch != null)
		{
			currentResearch.AddResearch(amount);
		}
	}

	public void RefreshResearchTree()
	{
		//TODO check conditions and add research items to list
	}

	public List<ResearchItem> AvailableResearch()
	{
		return unlockedResearch;
	}

	public void BeginResearch(ResearchItem researchItem)
	{
		currentResearch = researchItem;
		//TODO actually add research points towards tech
	}

	public void FinishResearch(ResearchItem researchItem)
	{
		unlockedResearch.Remove(researchItem);
		doneResearch.Add(researchItem);
	}
}
