using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchDisplayer : MonoBehaviour
{
	public GameObject title;
	public GameObject description;

	public ResearchItem selectedResearch;
	public GameObject researchButton;
	public GameObject contentView;

	ResearchHandler researchHandler;

	void Awake()
	{
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	public void SelectResearch(ResearchItem researchItem)
	{
		selectedResearch = researchItem;
		title.GetComponent<Text>().text = selectedResearch.title;
		description.GetComponent<Text>().text = selectedResearch.description;
	}

	public void BeginResearch()
	{
		researchHandler.BeginResearch(selectedResearch);
	}

	void OnEnable()
	{
		for (int i = 0; i < contentView.transform.childCount; i++)
		{
			Destroy(contentView.transform.GetChild(i).gameObject);
		}

		researchHandler.RefreshResearchTree();
		foreach (ResearchItem researchItem in researchHandler.AvailableResearch())
		{
			GameObject button = Instantiate(researchButton);
			button.transform.SetParent(contentView.transform);
			button.GetComponentInChildren<Text>().text = researchItem.title;
			button.GetComponent<ResearchButton>().researchItem = researchItem;
		}
	}
}
