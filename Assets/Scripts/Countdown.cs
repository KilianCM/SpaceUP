using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public Text uiText;
	public int value;

	private float elapsed = 0f;

	void Start()
	{
		uiText.text = value.ToString();
	}
	
	void Update () {
		elapsed += Time.deltaTime;
		if (elapsed >= 1f && value>=0){
			elapsed = elapsed % 1f;
			count();
		}
	}

	void count()
	{
		value -= 1;
		uiText.text = value.ToString();
		if (value == 0){
			gameObject.GetComponent<RocketFlight>().Launch();
			uiText.text = "Ignition !";
		}
		else if (value<0) {
			uiText.text = "";
		}
	}
}
