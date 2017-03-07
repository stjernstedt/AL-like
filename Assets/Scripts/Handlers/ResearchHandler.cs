using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchHandler : MonoBehaviour
{
	public GameObject research;
	UIHandler uiHandler;

	public ResearchItem currentResearch;
	public float researchProgress;

	public List<ResearchItem> lockedResearch = new List<ResearchItem>();
	public List<ResearchItem> unlockedResearch = new List<ResearchItem>();
	public List<ResearchItem> doneResearch = new List<ResearchItem>();

	// Use this for initialization
	public void Start()
	{
		uiHandler = FindObjectOfType<UIHandler>();
		lockedResearch.Add(research.GetComponent<Quarry>());
		unlockedResearch.Add(research.GetComponent<FusionPower>());
	}

	public void GenerateResearch(float amount)
	{
		if (currentResearch != null)
		{
			currentResearch.AddResearch(amount);
			researchProgress = currentResearch.researchProgress;
			if (currentResearch.researchProgress >= 1)
			{
				FinishResearch(currentResearch);
			}
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

	public float GetResearchProgress()
	{
		if (currentResearch != null)
		{
			return currentResearch.researchProgress;
		}
		else
		{
			return 0;
		}

	}
}
