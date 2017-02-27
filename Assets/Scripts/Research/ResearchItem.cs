using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResearchItem : MonoBehaviour
{
	public string title;
	public string description;
	public float cost;
	public float amountResearched;

	//TODO list with all requirements, make condition class?

	protected ResearchHandler researchHandler;

	void Start()
	{
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	public void FinishResearch()
	{
		researchHandler.FinishResearch(this);
	}

	public void AddResearch(float amount)
	{
		amountResearched += amount;
		if (amountResearched >= cost)
		{
			FinishResearch();
		}
	}
}
