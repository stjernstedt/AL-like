using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : MonoBehaviour
{
	public bool running = false;

	public abstract void Begin();
	public abstract void OnComplete();

}