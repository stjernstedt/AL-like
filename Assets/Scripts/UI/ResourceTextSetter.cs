using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTextSetter : MonoBehaviour
{
	public GameObject sliderPair;
	Resource resource;
	Slider slider;

	public void SetResource(Resource resource, GameObject sliderPair)
	{
		this.resource = resource;
		this.sliderPair = sliderPair;
		slider = sliderPair.GetComponentInChildren<Slider>();
		UpdateResource();
	}

	public Resource GetResource()
	{
		return resource;
	}

	public void UpdateResource()
	{
		GetComponent<Text>().text = resource.resourceName;
		transform.GetChild(0).GetComponent<Text>().text = "" + resource.amount;
		slider.maxValue = resource.amount;
	}
}