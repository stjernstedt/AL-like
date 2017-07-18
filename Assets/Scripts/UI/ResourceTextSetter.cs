using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTextSetter : MonoBehaviour
{
	Resource resource;
	Slider slider;

	//public void SetResource(string resourceName, float amount)
	//{
	//	GetComponent<Text>().text = resourceName;
	//	transform.GetChild(0).GetComponent<Text>().text = "" + amount;
	//}

	public void SetResource(Resource resource, Slider slider)
	{
		this.resource = resource;
		this.slider = slider;
		UpdateResource();
	}

	public void UpdateResource()
	{
		GetComponent<Text>().text = resource.resourceName;
		transform.GetChild(0).GetComponent<Text>().text = "" + resource.amount;
		slider.maxValue = resource.amount;
	}
}