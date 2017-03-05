using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchHandler : MonoBehaviour
{
	public GameObject research;
	UIHandler uiHandler;

	ResearchItem currentResearch;

	public List<ResearchItem> lockedResearch = new List<ResearchItem>();
	public List<ResearchItem> unlockedResearch = new List<ResearchItem>();
	public List<ResearchItem> doneResearch = new List<ResearchItem>();

	public float researchPoints
	{
		get; private set;
	}

	// Use this for initialization
	public void Start()
	{
		uiHandler = FindObjectOfType<UIHandler>();
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
		ResearchItem[] listCopy = lockedResearch.ToArray();
		foreach (ResearchItem item in listCopy)
		{
			bool passed = true;
			foreach (ICondition condition in item.conditions)
			{
				if (!condition.CheckCondition())
				{
					passed = false;
				}
			}

			if (passed)
			{
				unlockedResearch.Add(item);
				lockedResearch.Remove(item);
			}
		}
	}

	public List<ResearchItem> AvailableResearch()
	{
		return unlockedResearch;
	}

	public void BeginResearch(ResearchItem researchItem)
	{
		currentResearch = researchItem;
	}

	public void FinishResearch(ResearchItem researchItem)
	{
		unlockedResearch.Remove(researchItem);
		doneResearch.Add(researchItem);
		currentResearch = null;
		uiHandler.ShowPopup();
	}
}
