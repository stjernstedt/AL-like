using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCondition : ICondition
{
	public List<ResearchItem> requiredResearch = new List<ResearchItem>();

	ResearchHandler researchHandler;

	public ResearchCondition()
	{
		researchHandler = GameObject.FindObjectOfType<ResearchHandler>();
	}

	public bool CheckCondition()
	{
		bool passed = true;
		foreach (ResearchItem item in requiredResearch)
		{
			if (!researchHandler.doneResearch.Contains(item))
			{
				passed = false;
			}
		}

		return passed;
	}
}
