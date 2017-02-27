using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPopulator : MonoBehaviour
{
	public GameObject researchButton;
	ResearchHandler researchHandler;

	void Awake()
	{
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	void OnEnable()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}

		foreach (ResearchItem researchItem in researchHandler.AvailableResearch())
		{
			GameObject button = Instantiate(researchButton);
			button.transform.SetParent(transform);
			button.GetComponentInChildren<Text>().text = researchItem.title;
			button.GetComponent<ResearchButton>().researchItem = researchItem;
		}
	}

}
