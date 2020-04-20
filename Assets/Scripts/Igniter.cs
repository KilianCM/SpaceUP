using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igniter : MonoBehaviour
{
    public ParticleSystem fire;
    public bool isOn = false;
    public float duration=6000;

    private InfoDisplay infoDisplay;
    private float startTime;

    private void Start()
    {
        infoDisplay = gameObject.GetComponent<InfoDisplay>();
    }

    private void Update()
    {
        if(startTime + duration < Time.time)
        {
            isOn = false;
            fire.Stop();
        }
    }
    private void OnMouseDown()
    {
        if (infoDisplay.isSelected)
        {
            isOn = !isOn;
            if (isOn)
            {
                startTime = Time.time;
                fire.Play();
            }
            else
            {
                fire.Stop();
            }
        }
    }
}
