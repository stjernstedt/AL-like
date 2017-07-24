using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
	ResourcesHandler resourcesHandler;
	SceneHandler sceneHandler;

	GameObject objectBeingPlaced;
	bool placingObject;
	bool enoughResources;

	// Use this for initialization
	void Start()
	{
		sceneHandler = GetComponent<SceneHandler>();
	}

	// Update is called once per frame
	void Update()
	{
		if (placingObject)
		{
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);

			objectBeingPlaced.transform.position = pos;

			CheckResources();

			if (Input.GetMouseButtonDown(1))
			{
				placingObject = false;
				Destroy(objectBeingPlaced);
			}
			if (Input.GetMouseButtonDown(0))
			{
				if (enoughResources)
				{
					foreach (KeyValuePair<Resources, int> resource in objectBeingPlaced.GetComponent<Buildable>().resourcesNeeded)
					{
						switch (resource.Key)
						{
							case Resources.Energy:
								resourcesHandler.RemoveResource(Resources.Energy, resource.Value);
								break;
							case Resources.Ore:
								resourcesHandler.RemoveResource(Resources.Ore, resource.Value);
								break;
							default:
								break;
						}
					}

					objectBeingPlaced.GetComponent<ResourceGenerator>().enabled = true;
					objectBeingPlaced.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
					placingObject = false;
					objectBeingPlaced = null;
				}
			}
		}
	}

	public void PlaceBuildable(Buildables type)
	{
		//TODO rework data storing, add buildings to colony when placing etc
		resourcesHandler = sceneHandler.currentColony.GetComponent<ResourcesHandler>();
		switch (type)
		{
			case Buildables.PowerPlant:
				objectBeingPlaced = Instantiate(Prefabs.powerPlant);
				break;
			case Buildables.Mine:
				objectBeingPlaced = Instantiate(Prefabs.mine);
				break;
			case Buildables.ResearchLab:
				objectBeingPlaced = Instantiate(Prefabs.researchLab);
				break;
			default:
				break;
		}

		objectBeingPlaced.transform.SetParent(sceneHandler.currentColony.transform);
		objectBeingPlaced.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
		CheckResources();

		placingObject = true;
	}

	void CheckResources()
	{
		enoughResources = true;
		foreach (KeyValuePair<Resources, int> resource in objectBeingPlaced.GetComponent<Buildable>().resourcesNeeded)
		{
			switch (resource.Key)
			{
				case Resources.Energy:
					if (resource.Value > resourcesHandler.energy.amount)
					{
						objectBeingPlaced.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
						enoughResources = false;
					}
					break;
				case Resources.Ore:
					if (resource.Value > resourcesHandler.ore.amount)
					{
						objectBeingPlaced.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
						enoughResources = false;
					}
					break;
				default:
					break;
			}
		}
		if (enoughResources)
		{
			objectBeingPlaced.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
		}
	}
}
