using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour, ITickable
{

	// Use this for initialization
	void Start()
	{
		Init();
	}

	public void Init()
	{
		FindObjectOfType<Core>().tickables.Add(this);
	}

	public void Tick()
	{

	}

}