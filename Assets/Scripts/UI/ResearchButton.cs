using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchButton : MonoBehaviour
{
	public ResearchItem researchItem;

	public void SelectResearch()
	{
		FindObjectOfType<ResearchDisplayer>().SelectResearch(researchItem);
	}
}
