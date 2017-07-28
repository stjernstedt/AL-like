using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetView : MonoBehaviour, IView
{


	public void EndView()
	{
		gameObject.SetActive(false);
	}

	public void StartView()
	{
		gameObject.SetActive(true);
		UpdateView();
	}

	public void UpdateView()
	{

	}

}