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
	public GameObject researchBar;

	ResearchHandler researchHandler;

	void Awake()
	{
		researchHandler = FindObjectOfType<ResearchHandler>();
	}

	void Update()
	{
		//TODO tweak the way researchprogress is displayed/stored
		researchBar.GetComponent<Image>().fillAmount = researchHandler.researchProgress;
		//TODO reset progress when changing tech
		researchBar.GetComponentInChildren<Text>().text = (researchHandler.researchProgress * 100) + "%";
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
