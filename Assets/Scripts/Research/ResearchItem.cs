using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResearchItem : MonoBehaviour
{
	public string title;
	public string description;
	public float cost;
	public float amountResearched;
	public float researchProgress;

	public List<ICondition> conditions = new List<ICondition>();

	void Start()
	{
		Init();
	}

	public void AddResearch(float amount)
	{
		amountResearched += amount;
		researchProgress = amountResearched / cost;
	}

	public abstract void Init();
}
