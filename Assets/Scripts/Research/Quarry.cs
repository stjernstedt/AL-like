using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : ResearchItem, IResearchItem
{
	public override void Init()
	{
		ResearchCondition researchCondition = new ResearchCondition();
		researchCondition.requiredResearch.Add(GameObject.FindObjectOfType<FusionPower>());
		conditions.Add(researchCondition);
	}
}
