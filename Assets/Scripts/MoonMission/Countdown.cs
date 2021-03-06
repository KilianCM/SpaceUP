﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public Text uiText;
	public int value;
	public Button launchButton;
	public Button nextButton;
	public AudioSource sound;

	private float elapsed = 0f;
	private bool started = false;

	void Start()
	{
		uiText.text = value.ToString();
		launchButton.onClick.AddListener(StartCountdown);
	}

	void Update () {
        if(started)
        {
			elapsed += Time.deltaTime;
			if (elapsed >= 1f && value >= 0)
			{
				elapsed = elapsed % 1f;
				Count();
			}
		}
	}

    void StartCountdown()
    {
		launchButton.gameObject.SetActive(false);
		nextButton.gameObject.SetActive(true);
		uiText.gameObject.SetActive(true);
		sound.Play();
		started = true;
	}

	void Count()
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
