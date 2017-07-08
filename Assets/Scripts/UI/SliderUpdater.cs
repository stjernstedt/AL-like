using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
	public InputField inputField;
	Slider slider;

	// Use this for initialization
	void Start()
	{
		slider = GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void UpdateText()
	{
		inputField.text = "" + slider.value;
	}
}