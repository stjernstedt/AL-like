using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyButton : MonoBehaviour
{
	public GameObject colony;

	SceneHandler sceneHandler;

	void Awake()
	{
		sceneHandler = FindObjectOfType<SceneHandler>();
	}

	public void ActivateButton()
	{
		sceneHandler.ChangeColony(colony);
	}
}
