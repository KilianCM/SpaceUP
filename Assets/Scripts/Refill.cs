using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : MonoBehaviour
{
    public Material Material;
    public float fillAmount = -0.4f;
    public float refillSpeed = 0.1f;

    public bool refill = false;

    private void Update()
    {
        if(refill)
        {
            Material.SetFloat("_FillAmount", Material.GetFloat("_FillAmount")-(refillSpeed*Time.deltaTime));
            refill = Material.GetFloat("_FillAmount") > fillAmount;
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("refill");
        refill = true;
    }
}
